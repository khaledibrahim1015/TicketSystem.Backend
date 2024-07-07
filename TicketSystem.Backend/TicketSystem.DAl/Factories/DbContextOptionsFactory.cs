using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketSystem.Core.Configuration;
using TicketSystem.DAl.Data;

namespace TicketSystem.DAl.Factories
{
    /// <summary>
    /// Factory for creating DbContextOptions for TicketDbContext.
    /// </summary>
    public class DbContextOptionsFactory
    {
        private readonly AppSettings _appSettings;

        /// <summary>
        /// Initializes a new instance of the <see cref="DbContextOptionsFactory"/> class.
        /// </summary>
        /// <param name="appSettings">The application settings.</param>
        public DbContextOptionsFactory( IOptions<AppSettings> appSettings )
        {
            _appSettings = appSettings.Value;
        }

        /// <summary>
        /// Creates DbContextOptions for TicketDbContext.
        /// </summary>
        /// <returns>The created DbContextOptions.</returns>
        public DbContextOptions<TicketDbContext> CreateDbContextOptions()
        {
            DbContextOptionsBuilder<TicketDbContext> optionBuilder = new DbContextOptionsBuilder<TicketDbContext>();
            optionBuilder.UseSqlServer( _appSettings.ConnectionString );
            return optionBuilder.Options;
        }
    }
}
