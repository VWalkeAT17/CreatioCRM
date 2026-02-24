namespace Creatio.Copilot
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	using Creatio.FeatureToggling;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Factories;

	#region Class: IntentPromptBuilder

	[DefaultBinding(typeof(IIntentPromptBuilder))]
	internal class IntentPromptBuilder : IIntentPromptBuilder
	{

		#region Fields: Private

		private readonly UserConnection _userConnection;

		#endregion

		#region Constructors: Public

		/// <summary>
		/// Initializes a new instance of the <see cref="IntentPromptBuilder"/> class.
		/// </summary>
		/// <param name="userConnection">User connection.</param>
		public IntentPromptBuilder(UserConnection userConnection) {
			_userConnection = userConnection;
		}

		#endregion

		#region Methods: Private

		private static void AppendParameters(Dictionary<string, object> inputParameterValues,
				CopilotIntentSchema intent, StringBuilder prompt, bool includeOutputParametersInPrompt) {
			var parameterSectionFormatter = new IntentParametersSectionFormatter();
			if (inputParameterValues.Count > 0) {
				prompt.Append(Environment.NewLine);
				prompt.Append(parameterSectionFormatter
					.FormatInputParameters(intent.InputParameters, inputParameterValues));
			}
			if (intent.OutputParameters.Count <= 0 || !includeOutputParametersInPrompt) {
				return;
			}
			prompt.Append(Environment.NewLine);
			prompt.Append(parameterSectionFormatter.FormatOutputParameters(intent.OutputParameters));
		}

		private string GetFormattedPrompt(IDictionary<string, object> parameterValues, CopilotIntentSchema intent,
				HashSet<string> notSpecifiedKeys) {
			var inlineParameters = new Dictionary<string, object>(parameterValues);
			inlineParameters.AddRange(notSpecifiedKeys.ToDictionary(x => x, x => (object)string.Empty));
			return GenerateIntentPrompt(intent, inlineParameters);
		}

		private void GetExtraParameterNames(IDictionary<string, object> inputParameters,
				IList<string> warnings, List<string> inputParameterNames) {
			HashSet<string> extraParameterNames = inputParameters.Keys.ToHashSet();
			extraParameterNames.ExceptWith(inputParameterNames);
			if (extraParameterNames.Any()) {
				string warning = GetLocalizableString("WarningParameterNotExist")
					.Format(string.Join(",", extraParameterNames));
				warnings.Add(warning);
			}
		}

		private HashSet<string> GetNotSpecifiedParameters(IDictionary<string, object> inputParameters,
				List<string> inputParameterNames, IList<string> warnings) {
			var nonSpecified = new HashSet<string>(inputParameterNames);
			nonSpecified.ExceptWith(inputParameters.Keys);
			if (nonSpecified.Any()) {
				string warning = GetLocalizableString("WarningParameterValueNotSpecified")
					.Format(string.Join(",", nonSpecified));
				warnings.Add(warning);
			}
			return nonSpecified;
		}

		private LocalizableString GetLocalizableString(string localizableStringName) {
			string lsv = "LocalizableStrings." + localizableStringName + ".Value";
			return new LocalizableString(_userConnection.Workspace.ResourceStorage, nameof(CopilotEngine), lsv);
		}

		private string GenerateIntentPrompt(CopilotIntentSchema intent, IDictionary<string, object> parameterValues) {
			var formattingContext = new PromptTemplateFormattingContext(_userConnection) {
				VariableValues = parameterValues
			};
			return intent.PromptTemplate.Format(formattingContext);
		}

		#endregion

		#region Methods: Public

		/// <inheritdoc/>
		public string GenerateIntentPrompt(IDictionary<string, object> parameterValues, string additionalPromptText,
				CopilotIntentSchema intent, IList<string> warnings, bool includeOutputParametersInPrompt) {
			if (parameterValues == null) {
				parameterValues = new Dictionary<string, object>();
			}
			bool shouldInline = Features.GetIsEnabled<GenAIFeatures.UseInlineTemplateParameters>();
			List<string> intentInputParameters = intent.InputParameters.Select(x => x.Name).ToList();
			HashSet<string> notSpecifiedKeys = GetNotSpecifiedParameters(parameterValues,
				intentInputParameters, warnings);
			GetExtraParameterNames(parameterValues, warnings, intentInputParameters);
			var inputParameters = new Dictionary<string, object>(parameterValues);
			var prompt = new StringBuilder();
			if (shouldInline) {
				prompt.Append(GetFormattedPrompt(parameterValues, intent, notSpecifiedKeys));
				inputParameters = inputParameters.Where(x => !intentInputParameters.Contains(x.Key))
					.ToDictionary(x => x.Key, x => x.Value);
			} else {
				prompt.Append(intent.FullPrompt);
				foreach (string key in notSpecifiedKeys) {
					inputParameters[key] = null;
				}
			}
			if (!string.IsNullOrWhiteSpace(additionalPromptText)) {
				prompt.Append(Environment.NewLine);
				prompt.Append(additionalPromptText);
			}
			AppendParameters(inputParameters, intent, prompt, includeOutputParametersInPrompt);
			return prompt.ToString();
		}

		/// <inheritdoc/>
		public string GenerateIntentPrompt(IEnumerable<CopilotIntentSchema> intents,
				IDictionary<string, object> parameterValues) {
			var formattingContext = new PromptTemplateFormattingContext(_userConnection) {
				VariableValues = parameterValues
			};
			var separator = Environment.NewLine + Environment.NewLine;
			return intents.Select(x => x.PromptTemplate.Format(formattingContext)).ConcatIfNotEmpty(separator);
		}

		#endregion

	}

	#endregion

}

