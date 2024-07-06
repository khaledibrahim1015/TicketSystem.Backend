using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TicketSystem.Core.Configuration;
using TicketSystem.Core.Repositories;
using TicketSystem.Core.Repositories.Interfaces;
using TicketSystem.DAl.Data;
using TicketSystem.DAl.Factories;
using TicketSystem.DAl.Repositories;
using TicketSystem.DAl.Services;

namespace TicketSystem.DAl.Extensions
{
    public static class DependencyInjection
    {

        public static IServiceCollection AddServiceCollections (this IServiceCollection services , IConfiguration configuration)
        {
            // Configure AppSettings
            services.Configure<AppSettings>(configuration.GetSection("AppSettings"));
            // Register DbContext Using DbContextOptionsFactory 
            services.AddSingleton<DbContextOptionsFactory>();
            //  Register DbContext Using Factory 
            services.AddScoped(serviceProvider =>
            {
                var OptionsFactory = serviceProvider.GetRequiredService<DbContextOptionsFactory>();
                return new TicketDbContext(OptionsFactory.CreateDbContextOptions());
            });
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            //// Register other  services 
            //services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            //services.AddScoped<ITicketRepository , TicketRepository>();  
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            // add ticket handling as a backgroundservice 
            services.AddHostedService<TicketHandlingService>();
            return services;
        }
    }
}
