namespace TicketSystem.Core.DTOs.Responses
{
    /// <summary>
    /// Represents a paginated response for tickets.
    /// </summary>
    public class GetTicketsPaginatedResponse
    {
        /// <summary>
        /// Gets or sets the total count of tickets.
        /// </summary>
        public int TotalCount { get; set; }

        /// <summary>
        /// Gets or sets the paginated items.
        /// </summary>
        public IEnumerable<GetTicketResponse> Items { get; set;}
    }
}
