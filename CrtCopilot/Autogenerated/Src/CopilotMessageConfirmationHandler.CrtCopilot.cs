namespace Creatio.Copilot
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using Creatio.FeatureToggling;
	using Newtonsoft.Json;
	using Terrasoft.Common;
	using Terrasoft.Core.Factories;
	using Terrasoft.Configuration.GenAI;
	using Terrasoft.Core;
	using Terrasoft.Core.Applications.GenAI;
	using Terrasoft.Enrichment.Interfaces.ChatCompletion;

	#region Class: CopilotMessageConfirmationHandler

	/// <summary>
	/// Handles tool call confirmation logic for Copilot sessions.
	/// </summary>
	[DefaultBinding(typeof(ICopilotMessageConfirmationHandler))]
	internal class CopilotMessageConfirmationHandler : ICopilotMessageConfirmationHandler
	{

		#region Fields: Private

		private readonly ICopilotConfirmationMessageGenerator _messageGenerator;
		private readonly UserConnection _userConnection;
		private readonly string _failedToProcessConfirmationErrorMessage =
			"Failed to process confirmation response.";
		private readonly string _chatContextParameterName = "ChatContext";
		private readonly string _chatContextParameterDescription = 
			"The context of the chat to help the user make an informed decision.";

		#endregion

		#region Constructors: Public

		public CopilotMessageConfirmationHandler(ICopilotConfirmationMessageGenerator messageGenerator,
				UserConnection userConnection) {
			_messageGenerator = messageGenerator;
			_userConnection = userConnection;
		}

		#endregion

		#region Methods: Private

		private static string GetUserResponse(CopilotMessage userMessage) {
			return userMessage.Content;
		}

		private static CopilotMessage FindLastPendingConfirmationForToolCalls(IEnumerable<CopilotMessage> messages) {
			CopilotMessage result = messages.Where(i => !string.IsNullOrWhiteSpace(i.ToolCallIdsRequireConfirmation))
				.LastOrDefault(CopilotExtensions.IsPendingConfirmation);
			return result;
		}

		private bool IsConfirmedResponse(string userResponse, CopilotMessage pendingConfirmationMessage) {
			if (pendingConfirmationMessage?.Buttons == null || pendingConfirmationMessage.Buttons.Count == 0) {
				return false;
			}

			CopilotMessageButton matchedByCode = pendingConfirmationMessage.Buttons
				.FirstOrDefault(b => string.Equals(b.Code, userResponse, StringComparison.OrdinalIgnoreCase));
			
			if (matchedByCode != null) {
				return string.Equals(matchedByCode.Code, CopilotButtonCode.Yes, StringComparison.OrdinalIgnoreCase);
			}
			
			CopilotMessageButton matchedByCaption = pendingConfirmationMessage.Buttons
				.FirstOrDefault(b => string.Equals(b.Caption, userResponse, StringComparison.OrdinalIgnoreCase));

			if (matchedByCaption != null) {
				return string.Equals(matchedByCaption.Code, CopilotButtonCode.Yes, StringComparison.OrdinalIgnoreCase);
			}
			return IsConfirmedResponseWithIntent(userResponse, pendingConfirmationMessage);
		}
		
		private bool IsConfirmedResponseWithIntent(string userResponse, CopilotMessage pendingConfirmationMessage) {
			var options = pendingConfirmationMessage.Buttons.Select(b => new { b.Caption, b.Code }).ToList();
			var callResult = _userConnection.CopilotEngine.ExecuteIntent(new CopilotIntentCall() {
				IntentName = "SkillMatchConfirmationResponse",
				Parameters = new Dictionary<string, object> {
					{ "Options", options },
					{ "UserResponse", userResponse }
				},
				ToolCallOptions = new CopilotToolCallOptions() {
					ToolCallsEnabled = false
				}
			});
			if (!callResult.IsSuccess || string.IsNullOrEmpty(callResult.Content)) {
				throw new GenAIException(nameof(GenAIServiceErrorCode.UnknownError),
					callResult.ErrorMessage ?? _failedToProcessConfirmationErrorMessage);
			}
			if (callResult.ResultParameters.TryGetValue("SelectedOption", out var result)) {
				return (result as string)?.ToLower() == CopilotButtonCode.Yes.ToLower();
			}
			throw new GenAIException(nameof(GenAIServiceErrorCode.UnknownError), _failedToProcessConfirmationErrorMessage);
		}

		private static void AcceptToolCall(CopilotMessage pendingConfirmationMessage, IEnumerable<ToolCall> toolsToApprove) {
			pendingConfirmationMessage.ConfirmationResult = CopilotToolConfirmationResult.Approve;
			foreach (ToolCall toolCall in toolsToApprove) {
				toolCall.ConfirmationResult = CopilotToolConfirmationResult.Approve;
			}
		}

		private static void RejectToolCall(CopilotMessage pendingConfirmationMessage, IEnumerable<ToolCall> toolsToReject) {
			pendingConfirmationMessage.ConfirmationResult = CopilotToolConfirmationResult.Reject;
			foreach (ToolCall toolCall in toolsToReject) {
				toolCall.ConfirmationResult = CopilotToolConfirmationResult.Reject;
			}
		}

		private static CopilotConfirmationToolActionModel BuildToolAction(FunctionDefinition toolDefinition, ToolCall toolCall) {
			string argsJson = toolCall.FunctionCall?.Arguments;
			Dictionary<string, object> args = string.IsNullOrWhiteSpace(argsJson)
				? new Dictionary<string, object>()
				: JsonConvert.DeserializeObject<Dictionary<string, object>>(argsJson);

			List<ToolContextParameterModel> parameters = toolDefinition?.Parameters?.Properties?
				.Select(p => new ToolContextParameterModel {
					Name = p.Key,
					Description = p.Value?.Description,
					Type = p.Value?.Type,
					Value = args != null && args.TryGetValue(p.Key, out object arg) ? arg : null
				})
				.ToList() ?? new List<ToolContextParameterModel>();

			return new CopilotConfirmationToolActionModel {
				ToolCallId = toolCall.Id,
				ToolName = toolDefinition?.Name,
				Description = toolDefinition?.Description,
				Parameters = parameters
			};
		}

		private static CopilotConfirmationToolContextModel BuildToolContext(
				IEnumerable<FunctionDefinition> toolDefinitions, IEnumerable<ToolCall> toolCalls) {
			
			toolDefinitions = toolDefinitions ?? Enumerable.Empty<FunctionDefinition>();
			toolCalls = toolCalls ?? Enumerable.Empty<ToolCall>();
			
			Dictionary<string, FunctionDefinition> defs = toolDefinitions
				.ToDictionary(d => d?.Name, d => d);
			
			var ctx = new CopilotConfirmationToolContextModel();
			foreach (ToolCall call in toolCalls) {
				string name = call?.FunctionCall?.Name;
				if (string.IsNullOrWhiteSpace(name) || !defs.TryGetValue(name, out FunctionDefinition def)) {
					continue;
				}
				ctx.Actions.Add(BuildToolAction(def, call));
			}
			return ctx;
		}

		private static Dictionary<string, object> ParseArguments(string argumentsJson) {
			return argumentsJson.IsNotNullOrWhiteSpace()
				? JsonConvert.DeserializeObject<Dictionary<string, object>>(argumentsJson)
				: null;
		}

		private void AddChatContextAction(CopilotConfirmationToolContextModel toolContext, string chatContext) {
			toolContext.Actions.Add(new CopilotConfirmationToolActionModel() {
				Parameters = new List<ToolContextParameterModel>() {
					new ToolContextParameterModel() {
						Name = _chatContextParameterName,
						Description = _chatContextParameterDescription,
						Type = chatContext.GetType().Name,
						Value = chatContext
					}
				}
			});
		}

		/// <summary>
		/// Creates a confirmation message for the specified tool calls.
		/// </summary>
		/// <param name="toolDefinitions">The definitions of the tools.</param>
		/// <param name="toolCalls">The tool calls to confirm.</param>
		/// <param name="chatContext">The chat context to provide additional information for message generation.</param>
		/// <returns>A <see cref="CopilotMessage"/> representing the confirmation message.</returns>
		private CopilotMessage CreateConfirmationMessage(IEnumerable<FunctionDefinition> toolDefinitions, IEnumerable<ToolCall> toolCalls, string chatContext) {
			CopilotConfirmationToolContextModel toolContext = BuildToolContext(toolDefinitions, toolCalls);
			AddChatContextAction(toolContext, chatContext);
			return _messageGenerator.GenerateConfirmationMessage(toolContext);
		}

		private static List<CopilotMessage> ExecuteToolCallsIfNeed(IEnumerable<ToolCall> toolCalls,
			CopilotSession session, CopilotToolContext toolContext) {
			var messages = new List<CopilotMessage>();
			foreach (ToolCall handledTollCall in toolCalls) {
				string functionName = handledTollCall.FunctionCall.Name;
				if (!toolContext.Mapping.TryGetValue(functionName, out IToolExecutor executor)) {
					continue;
				}
				switch (executor?.IsConfirmationRequired) {
					case true when handledTollCall.ConfirmationResult == CopilotToolConfirmationResult.Reject:
						continue;
					case true when handledTollCall.ConfirmationResult == CopilotToolConfirmationResult.Approve:
						CopilotMessage toolCallMessage = CopilotMessage.FromAssistant(handledTollCall);
						messages.Add(toolCallMessage);
						Dictionary<string, object> arguments = ParseArguments(handledTollCall.FunctionCall.Arguments);
						List<CopilotMessage> copilotMessages = executor.Execute(handledTollCall.Id, arguments, session);
						messages.AddRange(copilotMessages);
						continue;
				}
			}
			return messages;
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Handles a user's confirmation response for tool calls in a Copilot session.
		/// Finds the last pending confirmation, determines if the response is approval or rejection,
		/// updates the tool calls' confirmation results, and executes approved tool calls.
		/// </summary>
		/// <param name="userMessage">The user's message containing the confirmation response.</param>
		/// <param name="session">The current Copilot session.</param>
		/// <param name="toolContext">The context with tool definitions and executors.</param>
		/// <returns>
		/// A list of Copilot messages resulting from executing approved tool calls, or an empty list if none were executed.
		/// </returns>
		public List<CopilotMessage> HandleConfirmation(CopilotMessage userMessage, CopilotSession session,
			CopilotToolContext toolContext) {
			if (Features.GetIsDisabled<GenAIFeatures.UseActionConfirmations>()) {
				return new List<CopilotMessage>();
			}
			List<CopilotMessage> messagesList = session.Messages.ToList();
			CopilotMessage pendingConfirmationMessage = FindLastPendingConfirmationForToolCalls(messagesList);
			if (pendingConfirmationMessage == null) {
				return new List<CopilotMessage>();
			}
			string userResponse = GetUserResponse(userMessage);
			bool isConfirmed = IsConfirmedResponse(userResponse, pendingConfirmationMessage);
			var handledTollCalls = new List<ToolCall>();
			IEnumerable<CopilotMessage> toolCallsLlmMessages = messagesList.Where(CopilotExtensions.IsToolCall)
				.Where(t => pendingConfirmationMessage.ToolCallIdsRequireConfirmation.Contains(t.ToolCallId));
			foreach (CopilotMessage toolCallsLlmMessage in toolCallsLlmMessages) {
				if (toolCallsLlmMessage?.ToolCalls == null) {
					continue;
				}
				if (isConfirmed) {
					AcceptToolCall(pendingConfirmationMessage, toolCallsLlmMessage.ToolCalls);
				} else {
					RejectToolCall(pendingConfirmationMessage, toolCallsLlmMessage.ToolCalls);
				}
				handledTollCalls.AddRange(toolCallsLlmMessage.ToolCalls);
			}
			List<CopilotMessage> executedMessages = ExecuteToolCallsIfNeed(handledTollCalls, session, toolContext);
			return executedMessages;
		}

		/// <summary>
		/// Processes the provided tool calls and generates a confirmation message if any tool calls require user confirmation.
		/// </summary>
		/// <param name="toolCalls">The collection of tool calls to evaluate.</param>
		/// <param name="toolContext">The context containing tool definitions and executors.</param>
		/// <param name="chatContext">The chat context to provide additional information for message generation.</param>
		/// <returns>A list containing a confirmation message if required; otherwise, an empty list.</returns>
		public List<CopilotMessage> GetConfirmationMessages(IEnumerable<ToolCall> toolCalls, CopilotToolContext toolContext, string chatContext) {
			var messages = new List<CopilotMessage>();
			Dictionary<string, IToolExecutor> toolMapping = toolContext.Mapping;
			FunctionDefinition[] functions = toolContext.Tools.Select(t => t.Function).ToArray();
			var toolCallsToConfirm = new List<ToolCall>();
			var toolDefinitionsToConfirm = new List<FunctionDefinition>();
			foreach (ToolCall toolCall in toolCalls) {
				string functionName = toolCall.FunctionCall.Name;
				if (!toolMapping.TryGetValue(functionName, out IToolExecutor executor)) {
					continue;
				}
				if (executor?.IsConfirmationRequired == false || !toolCall.ConfirmationResult.IsNullOrEmpty()) {
					continue;
				}
				toolCallsToConfirm.Add(toolCall);
				FunctionDefinition toolDefinition =
					functions.FirstOrDefault(t => t.Name == toolCall.FunctionCall.Name);
				if (toolDefinition != null) {
					toolDefinitionsToConfirm.Add(toolDefinition);
				}
			}
			if (!toolCallsToConfirm.Any() || !toolDefinitionsToConfirm.Any()) {
				return messages;
			}
			CopilotMessage confirmationMessage = CreateConfirmationMessage(toolDefinitionsToConfirm, toolCallsToConfirm, chatContext);
			messages.Add(confirmationMessage);
			return messages;
		}

		#endregion

	}

	#endregion

}
