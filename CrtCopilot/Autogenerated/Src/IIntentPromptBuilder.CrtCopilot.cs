namespace Creatio.Copilot
{
	using System.Collections.Generic;

	#region Interface: IIntentPromptBuilder

	/// <summary>
	/// Provides an abstraction for generating prompt strings for one or many copilot intents.
	/// </summary>
	internal interface IIntentPromptBuilder
	{

		#region Methods: Internal

		/// <summary>
		/// Generates a prompt for the specified <paramref name="intent"/> using supplied
		/// <paramref name="parameterValues"/>, optional <paramref name="additionalPromptText"/>
		/// and parameter inclusion options.
		/// </summary>
		/// <param name="parameterValues">Dictionary of input parameter names to values. May be <c>null</c>
		/// or empty.</param>
		/// <param name="additionalPromptText">Optional extra user / system instruction appended after the base
		/// intent prompt.</param>
		/// <param name="intent">The intent schema whose template and parameter metadata define
		/// the prompt structure.</param>
		/// <param name="warnings">A collection that will receive warning messages (e.g. missing or extra parameters).
		/// Never <c>null</c>.</param>
		/// <param name="includeOutputParametersInPrompt">When true, output parameter definitions
		/// are appended to guide model output.</param>
		/// <returns>The fully composed prompt text.</returns>
		string GenerateIntentPrompt(IDictionary<string, object> parameterValues, string additionalPromptText,
			CopilotIntentSchema intent, IList<string> warnings, bool includeOutputParametersInPrompt);

		/// <summary>
		/// Generates a combined prompt for multiple <paramref name="intents"/> using
		/// a shared <paramref name="parameterValues"/> dictionary.
		/// </summary>
		/// <param name="intents">Sequence of intent schemas to format. If empty, an empty string is returned.</param>
		/// <param name="parameterValues">Variable values dictionary reused for each intent template.</param>
		/// <returns>Concatenated prompt text (intents separated by a blank line) or empty string when
		/// no intents provided.</returns>
		string GenerateIntentPrompt(IEnumerable<CopilotIntentSchema> intents,
			IDictionary<string, object> parameterValues);

		#endregion

	}

	#endregion

}

