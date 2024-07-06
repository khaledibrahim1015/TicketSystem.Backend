using MediatR;
using TicketSystem.Core.DTOs.Requests;
using TicketSystem.Core.DTOs.Responses;

namespace TicketSystem.API.Commands
{
    public class CreateTicketCommand : IRequest<CreateTicketResponse>
    {
        public CreateTicketRequest TicketRequest { get; }

        public CreateTicketCommand(CreateTicketRequest ticketRequest)
        {
            TicketRequest = ticketRequest;
        }
    }
}
