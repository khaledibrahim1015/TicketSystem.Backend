using MediatR;

namespace TicketSystem.API.Commands
{
    public class HandleTicketCommand : IRequest<bool>
    {
        public int TicketId { get; }

        public HandleTicketCommand(int ticketId)
        {
            TicketId = ticketId;
        }
    }
}
