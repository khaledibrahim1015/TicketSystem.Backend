using TicketSystem.Core.Repositories;
using TicketSystem.Core.Repositories.Interfaces;
using TicketSystem.DAl.Data;

namespace TicketSystem.DAl.Repositories
{
    /// <summary>
    /// Unit of Work pattern implementation for managing repositories.
    /// </summary>
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly TicketDbContext _context;
        /// <summary>
        /// Gets the Ticket repository.
        /// </summary>
        public ITicketRepository Tickets { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="UnitOfWork"/> class.
        /// </summary>
        /// <param name="context">The TicketDbContext instance.</param>
        public UnitOfWork(TicketDbContext context)
        {
            _context = context;
            Tickets = new TicketRepository(context);
        }

        public bool Complete() => _context.SaveChanges() > 0;

        public async Task<bool> CompleteAsync() => await _context.SaveChangesAsync() > 0;

        public void Dispose() => _context.Dispose();
    }
}
