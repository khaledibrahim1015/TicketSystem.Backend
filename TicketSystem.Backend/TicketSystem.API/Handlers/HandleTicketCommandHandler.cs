using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TicketSystem.API.Commands;
using TicketSystem.Core.Repositories;

namespace TicketSystem.API.Handlers
{
    public class HandleTicketCommandHandler : IRequestHandler<HandleTicketCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;

        public HandleTicketCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(HandleTicketCommand request, CancellationToken cancellationToken)
        {
            var ticket = await _unitOfWork.Tickets.GetByIdAsync(request.TicketId);
            if (ticket != null)
            {
                ticket.IsHandled = true;
                return true; // await _unitOfWork.CompleteAsync();
            }

            return false;
        }
    }
}
