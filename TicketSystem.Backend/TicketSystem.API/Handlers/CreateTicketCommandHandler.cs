using AutoMapper;
using MediatR;
using TicketSystem.API.Commands;
using TicketSystem.Core.DTOs.Responses;
using TicketSystem.Core.Models;
using TicketSystem.Core.Repositories;

namespace TicketSystem.API.Handlers
{
    public class CreateTicketCommandHandler : IRequestHandler<CreateTicketCommand, CreateTicketResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateTicketCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<CreateTicketResponse> Handle(CreateTicketCommand request, CancellationToken cancellationToken)
        {
            var ticket = _mapper.Map<Ticket>(request.TicketRequest);

            await _unitOfWork.Tickets.AddAsync(ticket);
            await _unitOfWork.CompleteAsync();

            return _mapper.Map<CreateTicketResponse>(ticket);
        }
    }
}
