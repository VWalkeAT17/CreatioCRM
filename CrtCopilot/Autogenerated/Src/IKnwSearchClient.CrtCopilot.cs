namespace Creatio.Copilot
{
	using System.Threading;
	using System.Threading.Tasks;

	#region Interface: IKnwSearchClient

	/// <summary>
	/// Provides an interface for searching knowledge sources using a RAG service.
	/// </summary>
	public interface IKnwSearchClient
	{

		#region Methods: Public

		/// <summary>
		/// Asynchronously searches multiple knowledge sources by their identifiers and associated queries.
		/// </summary>
		/// <param name="request">The search request containing knowledge source queries, session ID
		/// and pagination options.</param>
		/// <param name="cancellationToken">A token to monitor for cancellation requests.
		/// Defaults to <see cref="CancellationToken.None"/> if not specified.</param>
		/// <returns>A task that represents the asynchronous operation. The task result contains
		/// a <see cref="KnwSearchDTO"/> object with the search results for each source.</returns>
		Task<KnwSearchDTO> SearchAsync(KnwSearchRequest request, CancellationToken cancellationToken = default);

		#endregion

	}

	#endregion

}

