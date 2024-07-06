using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TicketSystem.Core.Repositories;

namespace TicketSystem.DAl.Services
{
    public class TicketHandlingService : BackgroundService
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly ILogger<TicketHandlingService> _logger;
        private readonly TimeSpan _checkInterval = TimeSpan.FromMinutes(1);

        public TicketHandlingService(IServiceProvider serviceProvider, ILogger<TicketHandlingService> logger)
        {
            _serviceProvider = serviceProvider;
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                using (var scope = _serviceProvider.CreateScope())
                {
                    var unitOfWork = scope.ServiceProvider.GetRequiredService<IUnitOfWork>();

                    try
                    {
                        var tickets = await unitOfWork.Tickets.FindAllAsync(t => !t.IsHandled);
                        foreach (var ticket in tickets)
                        {
                            var timeSinceCreation = DateTime.UtcNow - ticket.CreationDate;
                            if (timeSinceCreation >= TimeSpan.FromMinutes(60))
                            {
                                ticket.IsHandled = true;
                            }
                        }

                        await unitOfWork.CompleteAsync();
                    }
                    catch (Exception ex)
                    {
                        _logger.LogError(ex, "An error occurred while handling tickets.");
                    }

                    await Task.Delay(_checkInterval, stoppingToken);
                }
            }
        }
    }
}
