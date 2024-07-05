using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketSystem.Core.Models;

namespace TicketSystem.DAl
{
    public  class TicketDbContext : DbContext
    {
        public TicketDbContext(DbContextOptions<TicketDbContext> options) :base(options)
        {
        }

        public DbSet<Ticket> Tikcets { get; set; }
    }
}
