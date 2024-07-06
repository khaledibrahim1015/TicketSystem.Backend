using TicketSystem.Core.Repositories.Interfaces;

namespace TicketSystem.Core.Repositories
{
    public  interface IUnitOfWork
    {
        //IBaseRepository<Ticket> Tickets { get; }
        ITicketRepository Tickets { get; }
        bool Complete();
        Task<bool> CompleteAsync();

    }
}
