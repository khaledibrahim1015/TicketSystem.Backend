using Microsoft.EntityFrameworkCore;
using TicketSystem.Core.Models;

namespace TicketSystem.DAl.Data
{
    public class TicketDbContext : DbContext
    {
        public TicketDbContext(DbContextOptions<TicketDbContext> options) : base(options) { }
        public DbSet<Ticket> Tikcets { get; set; }
    }
}
