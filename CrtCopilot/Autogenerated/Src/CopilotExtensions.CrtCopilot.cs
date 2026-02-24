namespace Creatio.Copilot
{
	using System;
	using System.Linq;
	using Terrasoft.Core;

	internal static class CopilotExtensions
	{

		#region Methods: Public

		public static CopilotIntentSchemaManager GetIntentSchemaManager(this UserConnection userConnection) {
			return userConnection.Workspace.SchemaManagerProvider.GetManager<CopilotIntentSchemaManager>();
		}

		public static bool IsToolCall(this CopilotMessage message) {
			return message != null && message.Role == CopilotMessageRole.Assistant &&
				message.ContentType != CopilotContentType.Confirmation && message.ToolCalls.Any() &&
				!string.IsNullOrWhiteSpace(message.ToolCallId);
		}

		public static bool IsConfirmation(this CopilotMessage message) {
			return message != null && message.Role == CopilotMessageRole.Assistant &&
				message.ContentType == CopilotContentType.Confirmation && message.Buttons.Any();
		}

		public static bool IsPendingConfirmation(this CopilotMessage message) {
			return IsConfirmation(message) && string.IsNullOrWhiteSpace(message.ConfirmationResult);
		}

		public static bool IsToolById(this CopilotMessage message, string toolCallId) {
			return IsTool(message) && message.ToolCallId == toolCallId;
		}

		public static bool IsTool(this CopilotMessage message) {
			return message != null && message.Role == CopilotMessageRole.Tool &&
				!string.IsNullOrWhiteSpace(message.ToolCallId);
		}

		public static string PrepareChatContext(CopilotSession session) {
			var chatContext = session.Messages.Where(x => x.Role != CopilotMessageRole.Tool
					&& x.Role != CopilotMessageRole.System
					&& x.Content != null)
				.Select(x => x.Content).ToList();
			return string.Join(Environment.NewLine, chatContext);
		}

	}

	#endregion

}

