# TicketSystem.Backend
# TicketSystem

Ticket System is a .NET Core application for managing tickets using CQRS, MediatR, and Repository Pattern.

## Table of Contents

1. [Overview](#overview)
2. [Features Implemented](#features-implemented)
3. [Design Patterns](#design-patterns)
4. [Technologies Used](#technologies-used)
5. [Setup and Configuration](#setup-and-configuration)
6. [Running the Application](#running-the-application)
7. [Example Usage](#example-usage)



## Overview

TicketSystem is designed to manage tickets with CRUD operations and includes features like handling overdue tickets automatically.

## Features Implemented

- **CQRS and MediatR**: Commands and queries are separated, enhancing application structure.
- **Repository Pattern**: Data access layer abstraction using interfaces for repositories.
- **Background Service**: Automatic handling of overdue tickets using a background service.[Example BackgroundService](#example-BackgroundService)

## Design Patterns

- **Repository Pattern**: Provides a consistent way to access and manipulate data.
- **Unit of Work**: Manages transactions across multiple repository operations.
- **MediatR and CQRS**: Encourages separation of concerns by handling commands and queries independently.
- **Factory DP**: For Register all Services In DI Container Across Application .
  

## Technologies Used

- ASP.NET Core
- Entity Framework Core
- MediatR
- AutoMapper

## Setup and Configuration

1. **Database Configuration**: Update the database connection string in `appsettings.json`.
2. **Dependency Injection**: Configure services  in `DependencyInjection.cs`. [Example Di](#example-Di)
3. **AutoMapper Configuration**: Define AutoMapper profiles for mapping DTOs to domain models.

## Running the Application

To run the TicketSystem locally:

1. Clone the repository: `git clone https://github.com/khaledibrahim1015/TicketSystem.git`
2. Navigate to the project directory: `cd TicketSystem`
3. Restore dependencies: `dotnet restore`
4. Update database: `dotnet ef database update`
5. Start the application: `dotnet run`
## Example BackgroundService
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

## Example Usage
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
     
### Creating a Ticket

To create a ticket, send a POST request to `/api/tickets` with JSON body:

```json
{
  "phoneNumber": "123456789",
  "governorate": "Governorate1",
  "city": "City1",
  "district": "District1"
}
