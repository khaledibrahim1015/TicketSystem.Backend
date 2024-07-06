using AutoMapper;
using MediatR;
using TicketSystem.API.Queries;
using TicketSystem.Core.DTOs.Responses;
using TicketSystem.Core.Repositories;

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
            var ticketResponses = _mapper.Map<IEnumerable<GetTicketResponse>>(tickets);

            foreach (var ticketResponse in ticketResponses)
            {
                ticketResponse.Color = GetTicketColor(ticketResponse.CreationDate);
            }

            return ticketResponses;
        }

        private string GetTicketColor(DateTime creationDate)
        {
            var ageInMinutes = (DateTime.UtcNow - creationDate).TotalMinutes;

            if (ageInMinutes <= 15)
                return "yellow";
            else if (ageInMinutes <= 30)
                return "green";
            else if (ageInMinutes <= 45)
                return "blue";
            else
                return "red";
        }
    }
}
