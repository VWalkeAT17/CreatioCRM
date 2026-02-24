namespace Creatio.Copilot
{
	using System.Collections.Generic;
	using Creatio.Copilot.Metadata;
	using Terrasoft.Enrichment.Interfaces.ChatCompletion;
	using Terrasoft.Enrichment.Interfaces.ChatCompletion.Responses;

	#region Interface: ICopilotToolProcessor

	internal interface ICopilotToolProcessor
	{

		#region Methods: Public

		CopilotToolContext GetToolContext(IEnumerable<CopilotActionMetaItem> actionItems, IEnumerable<CopilotIntentSchema> intents = null);

		List<CopilotMessage> HandleToolCalls(ChatCompletionResponse completionResponse, CopilotSession session,
			CopilotToolContext toolContext);

		#endregion

	}

	#endregion

}

