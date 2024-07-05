using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketSystem.Core.Configuration;

namespace TicketSystem.DAl.Factories
{
    public  class DbContextOptionsFactory
    {
        private readonly AppSettings _appSettings;

        public DbContextOptionsFactory( IOptions<AppSettings> appSettings )
        {
            _appSettings = appSettings.Value;
        }

        public DbContextOptions<TicketDbContext> CreateDbContextOptions()
        {
            DbContextOptionsBuilder<TicketDbContext> optionBuilder = new DbContextOptionsBuilder<TicketDbContext>();
            optionBuilder.UseSqlServer(
                                        _appSettings.ConnectionString );
            return optionBuilder.Options;

        }


    }
}
