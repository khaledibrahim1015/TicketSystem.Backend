using AutoMapper;
using MediatR;
using TicketSystem.API.Queries;
using TicketSystem.Core.DTOs.Responses;
using TicketSystem.Core.Repositories;
using TicketSystem.DAl.Services;

namespace TicketSystem.API.Handlers
{
    public class GetAllTicketsPaginatedQueryHandler : IRequestHandler<GetAllTicketsPaginatedQuery, IEnumerable<GetTicketResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllTicketsPaginatedQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GetTicketResponse>> Handle(GetAllTicketsPaginatedQuery request, CancellationToken cancellationToken)
        {
            var tickets = await _unitOfWork.Tickets.GetPaginatedTicketsAsync(request.PageNumber, request.PageSize);
            var ticketResponses = await Task.Run(() => _mapper.Map<IEnumerable<GetTicketResponse>>(tickets)); // Ensure mapping is awaited

            foreach (var ticketResponse in ticketResponses)
            {
                ticketResponse.Color = TicketService.GetTicketColor(ticketResponse.CreationDate);
            }

            return ticketResponses;
        }



   
    }
}
