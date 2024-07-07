using System.Linq.Expressions;
using TicketSystem.Core.Consts;
using TicketSystem.Core.Models;

namespace TicketSystem.Core.Repositories.Interfaces
{
    /// <summary>
    /// Interface for ticket repository.
    /// </summary>
    public interface ITicketRepository : IBaseRepository<Ticket>
    {
        /// <summary>
        /// Gets paginated tickets asynchronously.
        /// </summary>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the list of tickets.</returns>
        Task<IEnumerable<Ticket>> GetPaginatedTicketsAsync(int pageNumber, int pageSize);

        /// <summary>
        /// Gets paginated tickets asynchronously with order by.
        /// </summary>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="orderby">The order by expression.</param>
        /// <param name="orderbyDire">The order by direction.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the list of tickets.</returns>
        Task<IEnumerable<Ticket>> GetPaginatedTicketsAsync(int pageNumber, int pageSize, Expression<Func<Ticket, object>> orderby = null, string orderbyDire = OrderBy.Ascending);

        /// <summary>
        /// Gets paginated tickets asynchronously with criteria.
        /// </summary>
        /// <param name="criteria">The criteria expression.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="orderby">The order by expression.</param>
        /// <param name="orderbyDire">The order by direction.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the list of tickets.</returns>
        Task<IEnumerable<Ticket>> GetPaginatedTicketsAsync(Expression<Func<Ticket, bool>> criteria, int pageNumber, int pageSize, Expression<Func<Ticket, object>> orderby = null, string orderbyDire = OrderBy.Ascending);

        /// <summary>
        /// Handles the ticket asynchronously.
        /// </summary>
        /// <param name="id">The ticket identifier.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        Task HandleTicketAsync(int id);
    }
}
