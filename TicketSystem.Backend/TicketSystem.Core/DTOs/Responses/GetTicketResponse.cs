using TicketSystem.Core.Models;

namespace TicketSystem.Core.DTOs.Responses
{
    /// <summary>
    /// Represents a response for getting a ticket.
    /// </summary>
    public class GetTicketResponse : Ticket
    {
        /// <summary>
        /// Gets or sets the color.
        /// </summary>
        public string Color { get; set; } = string.Empty;
    }
}
