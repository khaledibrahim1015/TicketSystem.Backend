using TicketSystem.Core.Models;

namespace TicketSystem.Core.DTOs.Responses
{
    public class GetTicketResponse : Ticket
    {
        public string Color { get; set; } = string.Empty;
      
    }
}
