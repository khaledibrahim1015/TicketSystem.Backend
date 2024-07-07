using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TicketSystem.Core.Consts;
using TicketSystem.Core.Models;
using TicketSystem.Core.Repositories.Interfaces;
using TicketSystem.DAl.Data;

namespace TicketSystem.DAl.Repositories
{
    /// <summary>
    /// Repository for managing Ticket entities.
    /// </summary>
    public class TicketRepository : BaseRepository<Ticket>, ITicketRepository
    {
        private readonly TicketDbContext _context;
        public TicketRepository(TicketDbContext context) : base(context) { }
        /// <summary>
        /// Paginated function 
        /// </summary>
        /// <param name="pageNumber"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public async Task<IEnumerable<Ticket>> GetPaginatedTicketsAsync(int pageNumber, int pageSize)
        {
            var x = await _dbSet.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
            return x;
        }
        /// <summary>
        /// Paginated function 
        /// </summary>
        /// <param name="pageNumber"></param>
        /// <param name="pageSize"></param>
        /// <param name="orderby"></param>
        /// <param name="orderbyDire"></param>
        /// <returns></returns>
        public async Task<IEnumerable<Ticket>> GetPaginatedTicketsAsync(int pageNumber, int pageSize, Expression<Func<Ticket, object>> orderby = null, string orderbyDire = OrderBy.Ascending)
        {
            IQueryable<Ticket> query = _dbSet.Skip((pageNumber - 1) * pageSize).Take(pageSize);
            if (orderby != null)
            {
                query = orderbyDire == OrderBy.Ascending ? query.OrderBy(orderby) : query.OrderByDescending(orderby);
            }
            return await query.ToListAsync();
        }

        public async Task<IEnumerable<Ticket>> GetPaginatedTicketsAsync(Expression<Func<Ticket, bool>> criteria, int pageNumber, int pageSize, Expression<Func<Ticket, object>> orderby = null, string orderbyDire = OrderBy.Ascending)
        {
            IQueryable<Ticket> query = _dbSet.Where(criteria).Skip((pageNumber - 1) * pageSize).Take(pageSize);
            if (orderby != null)
            {
                query = orderbyDire == OrderBy.Ascending ? query.OrderBy(orderby) : query.OrderByDescending(orderby);
            }
            return await query.ToListAsync();
        }

        public async Task HandleTicketAsync(int id)
        {
            var ticket = await GetByIdAsync(id);
            if (ticket != null)
            {
                ticket.IsHandled = true;
                await _context.SaveChangesAsync();
            }
        }
    }
}
