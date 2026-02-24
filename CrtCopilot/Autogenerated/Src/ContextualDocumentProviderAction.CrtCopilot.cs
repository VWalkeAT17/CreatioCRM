namespace Creatio.Copilot
{
	using System;
	using System.Collections.Generic;
	using System.Text;
	using System.Linq;
	using Newtonsoft.Json;
	using Common.Logging;
	using Creatio.Copilot.Actions;
	using Creatio.FeatureToggling;
	using Terrasoft.Common;
	using Terrasoft.Common.Threading;
	using Terrasoft.Core;
	using Terrasoft.Core.Factories;
	using Terrasoft.File;
	using Terrasoft.File.Abstractions.TextExtraction;

	#region Class: ContextualDocumentProviderAction

	/// <summary>
	/// Contextual document provider code action.
	/// </summary>
	public class ContextualDocumentProviderAction : BaseExecutableCodeAction
	{

		#region Class: KnowledgeSourceQuery

		/// <summary>
		/// Represents a knowledge source and its associated query for RAG search.
		/// </summary>
		private class KnowledgeSourceQuery
		{

			#region Properties: Public

			/// <summary>
			/// The unique identifier of the knowledge source.
			/// </summary>
			[JsonProperty("knwSourceId")]
			public Guid KnwSourceId { get; set; }

			/// <summary>
			/// The query associated with the knowledge source.
			/// </summary>
			[JsonProperty("query")]
			public string Query { get; set; }

			#endregion

		}

		#endregion

		#region Constants: Private

		private const string CaptionValue = "Get documents content.";
		private const string DescriptionValue = "Provides content of the documents that have been added to the conversation.";
		private const string FileMarkerFormatValue = "#FileId: {0}, #FileName: {1}";
		private const string ContentMarkerValue = "#Content:";
		private const string ContentMarkerErrorValue = "#Content: Error retrieving document content.";
		private const string SessionNotFoundErrorMessage = "Session not found";
		private const string KnwSourcesParameter = "knwSources";
		private const string DocumentIdsParameter = "DocumentIds";
		private const string DocumentsSectionTitle = "#DOCUMENTS:";
		private const string KnwSectionTitle = "#KNOWLEDGE SOURCES:";
		private const string FailedKnwSectionTitle = "#FAILED KNOWLEDGE SOURCES:";

		#endregion

		#region Constructors: Internal

		/// <summary>
		/// Initializes a new instance of the <see cref="ContextualDocumentProviderAction"/> class.
		/// </summary>
		/// <param name="logger">An instance of the <see cref="ILog"/> implementing type to initialize the current
		/// instance with.</param>
		internal ContextualDocumentProviderAction(ILog logger): this() {
			_logger = logger;
		}

		#endregion

		#region Constructors: Public

		/// <summary>
		/// Initializes a new instance of the <see cref="ContextualDocumentProviderAction"/> class.
		/// </summary>
		public ContextualDocumentProviderAction() {
			if (IsKnwRetrievalEnabled()) {
				Parameters = new List<SourceCodeActionParameter> {
					new SourceCodeActionParameter {
						Name = KnwSourcesParameter,
						Caption = new LocalizableString("Knowledge sources and queries for RAG search"),
						Description = new LocalizableString(
							"Generate array of objects where each object contains a knowledge source ID and its " +
							"corresponding query. If no knowledge sources send empty array."),
						IsRequired = true,
						DataValueTypeUId = DataValueType.CompositeObjectListDataValueTypeUId,
						ItemProperties = new List<SourceCodeActionParameter> {
							new SourceCodeActionParameter {
								Name = "knwSourceId",
								Caption = new LocalizableString("Knowledge Source ID"),
								Description = new LocalizableString("The unique identifier of the knowledge source."),
								IsRequired = true,
								DataValueTypeUId = DataValueType.GuidDataValueTypeUId
							},
							new SourceCodeActionParameter {
								Name = "query",
								Caption = new LocalizableString("Query"),
								Description = new LocalizableString("The query associated with the knowledge source."),
								IsRequired = true,
								DataValueTypeUId = DataValueType.TextDataValueTypeUId
							}
						}
					},
					new SourceCodeActionParameter {
						Name = DocumentIdsParameter,
						Caption = new LocalizableString("Document IDs"),
						Description = new LocalizableString(
							"Generate array of document identifiers (GUIDs) to filter available documents for those " +
							"that should be used as context. If all documents are required or no documents available send an empty array."),
						IsRequired = true,
						DataValueTypeUId = DataValueType.TextDataValueTypeUId
					}
				};
			}
		}

		#endregion

		#region Properties: Private

		private ILog _logger;
		private ILog Logger => _logger ?? (_logger = LogManager.GetLogger("Copilot"));

		#endregion

		#region Methods: Private

		private static void AppendFormatedLineOfKnwItem(StringBuilder contentBuilder, Guid knwSourceId,
			string message, double? score = null, string source = null, string location = null) {
			var metadata = new List<string>();
			if (score.HasValue && score.Value > 0) {
				metadata.Add($"score={score.Value:F2}");
			}
			if (!string.IsNullOrWhiteSpace(source)) {
				metadata.Add($"source=\"{source}\"");
			}
			if (!string.IsNullOrWhiteSpace(location)) {
				metadata.Add($"location=\"{location}\"");
			}
			string metadataStr = metadata.Count > 0 ? $" ({string.Join(", ", metadata)})" : string.Empty;
			contentBuilder.AppendLine($"- [{knwSourceId}]{metadataStr} {{{message}}}");
		}

		private static bool IsKnwRetrievalEnabled() {
			return Features.GetIsEnabled<GenAIFeatures.EnableKnwRetrieval>();
		}

		private void RenderDocument(StringBuilder contentBuilder, ICreatioAIDocument document,
				ITextContentExtractor contentExtractor) {
			contentBuilder.AppendFormat(FileMarkerFormatValue, document.FileId, document.FileName);
			contentBuilder.AppendLine();
			var entityFileLocator = new EntityFileLocator(document.FileSchemaName, document.FileId);
			try {
				string content = contentExtractor.ExtractText(entityFileLocator);
				contentBuilder.AppendLine(ContentMarkerValue);
				contentBuilder.AppendLine(content);
			} catch (Exception e) {
				Logger.Error($"Error retrieving document content for {document.FileName}", e);
				contentBuilder.AppendLine(ContentMarkerErrorValue);
			}
			contentBuilder.AppendLine();
		}

		private void HandleKnowledgeRetrieval(ActionExecutionOptions options, StringBuilder contentBuilder,
				Guid sessionId) {
			if (!IsKnwRetrievalEnabled()) {
				return;
			}
			contentBuilder.AppendLine(KnwSectionTitle);
			if (!options.ParameterValues.TryGetValue(KnwSourcesParameter, out string value) || value.IsNullOrEmpty()) {
				contentBuilder.AppendLine("No knowledge sources or queries provided.");
				contentBuilder.AppendLine(DocumentsSectionTitle);
				return;
			}
			List<KnowledgeSourceQuery> knwSources;
			try {
				knwSources = JsonConvert.DeserializeObject<List<KnowledgeSourceQuery>>(value);
			} catch (JsonException ex) {
				Logger.Error("Failed to parse knwSources JSON parameter.", ex);
				contentBuilder.AppendLine("Failed to parse knwSources JSON parameter.");
				return;
			}
			if (knwSources == null || knwSources.Count == 0) {
				contentBuilder.AppendLine("No knowledge sources or queries matched the provided data.");
				contentBuilder.AppendLine(DocumentsSectionTitle);
				return;
			}
			IKnwSearchClient knwSearchClient;
			try {
				knwSearchClient = ClassFactory.Get<IKnwSearchClient>();
			} catch (Exception ex) {
				Logger.Error("Failed to resolve IKnwSearchClient.", ex);
				contentBuilder.AppendLine("Failed to resolve knowledge search client.");
				contentBuilder.AppendLine(DocumentsSectionTitle);
				return;
			}
			Dictionary<Guid, IEnumerable<string>> knwDict = knwSources.Where(q =>
					q != null && q.KnwSourceId.IsNotEmpty() && q.Query.IsNotNullOrEmpty())
				.GroupBy(q => q.KnwSourceId)
				.ToDictionary(
					g => g.Key,
					g => g.Select(q => q.Query)
				);
			if (knwDict.Count == 0) {
				contentBuilder.AppendLine("No valid knowledge source queries provided.");
				contentBuilder.AppendLine(DocumentsSectionTitle);
				return;
			}
			KnwSearchDTO knwDto;
			try {
				var request = new KnwSearchRequest {
					KnwSourceQueries = knwDict,
					SessionId = sessionId
				};
				knwDto = AsyncPump.Run(() => knwSearchClient.SearchAsync(request));
			} catch (Exception ex) {
				Logger.Error("Failed to retrieve information.", ex);
				contentBuilder.AppendLine("Failed to retrieve information.");
				return;
			}
			if (knwDto == null || (knwDto.KnwItems.IsNullOrEmpty() && knwDto.ErrorMessage.IsNullOrEmpty())) {
				contentBuilder.AppendLine("No relevant documents found for the given data.");
				contentBuilder.AppendLine(DocumentsSectionTitle);
				return;
			}
			if (knwDto.ErrorMessage.IsNotNullOrEmpty()) {
				contentBuilder.AppendLine(knwDto.ErrorMessage);
				contentBuilder.AppendLine(DocumentsSectionTitle);
				return;
			}
			foreach (KnwSearchItemResponse result in knwDto.KnwItems
						.Where(i => i.Error.IsNullOrEmpty())) {
				double? score = result.Score > 0 ? result.Score : (double?)null;
				string source = !string.IsNullOrWhiteSpace(result.ItemDetail?.Title)
					? result.ItemDetail.Title
					: null;
				string location = result.ItemDetail?.Location;
				AppendFormatedLineOfKnwItem(contentBuilder, result.KnwSourceId, result.Response, score, source, location);
			}
			IEnumerable<KnwSearchItemResponse> errorItems = knwDto.KnwItems
				.Where(i => !i.Error.IsNullOrEmpty());
			if (errorItems.Any()) {
				contentBuilder.AppendLine(FailedKnwSectionTitle);
				foreach (KnwSearchItemResponse result in errorItems) {
					AppendFormatedLineOfKnwItem(contentBuilder, result.KnwSourceId, result.Error);
				}
			}
			contentBuilder.AppendLine(DocumentsSectionTitle);
		}

		private void HandleDocumentRetrieval(CopilotSession session, StringBuilder sb, ActionExecutionOptions options) {
			var contentExtractor = ClassFactory.Get<ITextContentExtractor>();
			IList<ICreatioAIDocument> documents = session.Documents;
			if (IsKnwRetrievalEnabled()) {
				List<Guid> documentIds = null;
				if (options.ParameterValues.TryGetValue(DocumentIdsParameter, out string documentIdsRaw)
					&& !string.IsNullOrEmpty(documentIdsRaw)) {
					try {
						documentIds = JsonConvert.DeserializeObject<List<Guid>>(documentIdsRaw);
					} catch {
						Logger.Warn("Failed to parse DocumentIds parameter as List<Guid>.");
					}
				}
				if (documentIds != null && documentIds.Count > 0) {
					documents = documents.Where(d => documentIds.Contains(d.FileId)).ToList();
				}
			}
			if (documents.Count > 0) {
				foreach (ICreatioAIDocument document in documents) {
					RenderDocument(sb, document, contentExtractor);
				}
			} else {
				sb.AppendLine("No documents have been uploaded or attached to the conversation, " +
					"or none matched the provided DocumentIds.");
				sb.AppendLine(
					"Upload a file to session or use skill SkillAttachFileToConversation if attaching existing files.");
			}
		}

		#endregion

		#region Methods: Public

		/// <inheritdoc />
		public override LocalizableString GetCaption() {
			return new LocalizableString(CaptionValue);
		}

		/// <inheritdoc />
		public override LocalizableString GetDescription() {
			return new LocalizableString(DescriptionValue);
		}

		/// <inheritdoc />
		public override CopilotActionExecutionResult Execute(ActionExecutionOptions options) {
			var sessionManager = ClassFactory.Get<ICopilotSessionManager>();
			CopilotSession session = sessionManager.FindById(options.CopilotSessionUId);
			if (session == null) {
				Logger.Error($"Session {options.CopilotSessionUId} not found.");
				return new CopilotActionExecutionResult {
					Status = CopilotActionExecutionStatus.Failed,
					ErrorMessage = SessionNotFoundErrorMessage
				};
			}
			var sb = new StringBuilder();
			HandleKnowledgeRetrieval(options, sb, options.CopilotSessionUId);
			HandleDocumentRetrieval(session, sb, options);
			return new CopilotActionExecutionResult {
				Status = CopilotActionExecutionStatus.Completed,
				Response = sb.ToString(),
				ResponseOptions = new ActionResponseOptions {
					TruncateContentOnSave = true
				}
			};
		}

		#endregion

	}

	#endregion

}
