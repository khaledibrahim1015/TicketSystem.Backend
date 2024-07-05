using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TicketSystem.Core.Configuration;
using TicketSystem.DAl.Factories;

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

            // Register other  services 
            





            return services;
        }



    }
}
