using MediatR;
using TicketSystem.Core.DTOs.Responses;

namespace TicketSystem.API.Queries
{
    public class GetAllTicketsPaginatedQuery : IRequest<IEnumerable<GetTicketResponse>>
    {
        public int PageNumber { get; }
        public int PageSize { get; }

        public GetAllTicketsPaginatedQuery(int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
        }
    }
}
