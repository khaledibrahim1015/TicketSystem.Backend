using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TicketSystem.API.Queries;
using TicketSystem.Core.DTOs.Responses;
using TicketSystem.Core.Repositories;
using TicketSystem.DAl.Services;

namespace TicketSystem.API.Handlers
{
    public class GetAllTicketsPaginatedQueryHandler : IRequestHandler<GetAllTicketsPaginatedQuery, GetTicketsPaginatedResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllTicketsPaginatedQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<GetTicketsPaginatedResponse> Handle(GetAllTicketsPaginatedQuery request, CancellationToken cancellationToken)
        {
            var tickets = await _unitOfWork.Tickets.GetPaginatedTicketsAsync(request.PageNumber, request.PageSize);
            var totalCount = await _unitOfWork.Tickets.CountAsync(); // Fetch total count from repository

            var ticketResponses = _mapper.Map<IEnumerable<GetTicketResponse>>(tickets); // Map IEnumerable<Ticket> to IEnumerable<GetTicketResponse>

            foreach (var ticketResponse in ticketResponses)
            {
                ticketResponse.Color = TicketService.GetTicketColor(ticketResponse.CreationDate);
            }

            var response = new GetTicketsPaginatedResponse
            {
                Items = ticketResponses,
                TotalCount = totalCount // Assign total count obtained from repository
            };

            return response;
        }
    }
}
