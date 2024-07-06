using System.Linq.Expressions;
using TicketSystem.Core.Consts;
using TicketSystem.Core.Models;

namespace TicketSystem.Core.Repositories.Interfaces
{
    public interface ITicketRepository :  IBaseRepository<Ticket>
    {
        //  use add   Task<bool> AddAsync(TEntity entity);
        //Task AddTicketAsync(Ticket ticket);
        Task<IEnumerable<Ticket>> GetPaginatedTicketsAsync(int pageNumber, int pageSize);
        Task<IEnumerable<Ticket>> GetPaginatedTicketsAsync(int pageNumber, int pageSize, Expression<Func<Ticket, object>> orderby = null, string orderbyDire = OrderBy.Ascending);
        Task<IEnumerable<Ticket>> GetPaginatedTicketsAsync(Expression<Func<Ticket, bool>> criteria, int pageNumber, int pageSize, Expression<Func<Ticket, object>> orderby = null, string orderbyDire = OrderBy.Ascending);
        Task HandleTicketAsync(int id);
    }
}
