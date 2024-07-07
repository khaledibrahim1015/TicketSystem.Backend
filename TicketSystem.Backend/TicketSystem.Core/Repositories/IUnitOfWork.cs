using TicketSystem.Core.Repositories.Interfaces;

namespace TicketSystem.Core.Repositories
{
    /// <summary>
    /// Interface for unit of work.
    /// </summary>
    public interface IUnitOfWork
    {
        ITicketRepository Tickets { get; }
        bool Complete();
        Task<bool> CompleteAsync();
    }
}
