namespace Creatio.Copilot
{
	using System.Collections.Generic;
	using Terrasoft.Enrichment.Interfaces.ChatCompletion;

	#region Interface: ICopilotMessageConfirmationHandler

	internal interface ICopilotMessageConfirmationHandler
	{
		List<CopilotMessage> HandleConfirmation(CopilotMessage userMessage, CopilotSession session,
			CopilotToolContext toolContext);

		List<CopilotMessage> GetConfirmationMessages(IEnumerable<ToolCall> toolCalls, CopilotToolContext toolContext, string chatContext);
	}

	#endregion

}
