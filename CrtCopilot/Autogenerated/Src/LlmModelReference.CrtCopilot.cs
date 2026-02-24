namespace Creatio.Copilot
{
    using System;

    #region Class: LlmModelReference

    /// <summary>
    /// Lightweight reference to an LLM model containing only essential identification data.
    /// </summary>
    public class LlmModelReference
    {
        public Guid Id { get; set; }
        public string Code { get; set; }
    }

    #endregion
}

