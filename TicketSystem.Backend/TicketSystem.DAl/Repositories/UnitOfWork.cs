using TicketSystem.Core.Repositories;
using TicketSystem.Core.Repositories.Interfaces;
using TicketSystem.DAl.Data;

namespace TicketSystem.DAl.Repositories
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly TicketDbContext _context;
        public ITicketRepository Tickets { get; private set; }

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
