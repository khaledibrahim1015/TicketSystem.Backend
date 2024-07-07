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
8. [Validators](#validators)

## Overview

TicketSystem is designed to manage tickets with CRUD operations and includes features like handling overdue tickets automatically.

## Features Implemented

- **CQRS and MediatR**: Commands and queries are separated, enhancing application structure.
- **Repository Pattern**: Data access layer abstraction using interfaces for repositories.
- **Background Service**: Automatic handling of overdue tickets using a background service.

## Design Patterns

- **Repository Pattern**: Provides a consistent way to access and manipulate data.
- **Unit of Work**: Manages transactions across multiple repository operations.
- **MediatR and CQRS**: Encourages separation of concerns by handling commands and queries independently.
- **Factory DP**: For Register all Services In DI Container Across Application.

## Technologies Used

- ASP.NET Core
- Entity Framework Core
- MediatR
- AutoMapper

## Setup and Configuration

1. **Database Configuration**: Update the database connection string in `appsettings.json`.
2. **Dependency Injection**: Configure services in `DependencyInjection.cs`.

## Running the Application

To run the TicketSystem locally:

1. Clone the repository: `git clone https://github.com/khaledibrahim1015/TicketSystem.git`
2. Navigate to the project directory: `cd TicketSystem`
3. Restore dependencies: `dotnet restore`
4. Update database: `dotnet ef database update`
5. Start the application: `dotnet run`

## Example Usage

### Example BackgroundService

The `TicketHandlingService` class demonstrates how overdue tickets are automatically handled in the background:

```csharp
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
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


Validators
CreateTicketRequest Validator

The CreateTicketRequestValidator ensures that the incoming ticket creation requests are valid:

public class CreateTicketRequestValidator : AbstractValidator<CreateTicketRequest>
{
    public CreateTicketRequestValidator()
    {
        RuleFor(x => x.PhoneNumber).NotEmpty().MaximumLength(20);
        RuleFor(x => x.Governorate).NotEmpty().MaximumLength(50);
        RuleFor(x => x.City).NotEmpty().MaximumLength(50);
        RuleFor(x => x.District).NotEmpty().MaximumLength(50);
    }
}



Endpoints

The TicketSystem API provides several endpoints to manage tickets and retrieve static data.
1. Create Ticket

Endpoint: POST /api/tickets

Creates a new ticket with the provided details.

Request Body:

json

{
  "phoneNumber": "1234567890",
  "governorate": "Governorate1",
  "city": "City1",
  "district": "District1"
}

2. Handle Ticket

Endpoint: GET /api/tickets/{id}/handle

Marks a ticket as handled based on its ID.

Response: Returns 200 OK if successful.
3. Get Paginated Tickets

Endpoint: GET /api/tickets/paginated?pageNumber={pageNumber}&pageSize={pageSize}

Retrieves a paginated list of tickets.

json

[
  {
    "id": 1,
    "creationDate": "2024-07-06T10:00:00Z",
    "phoneNumber": "1234567890",
    "governorate": "Governorate1",
    "city": "City1",
    "district": "District1",
    "isHandled": false,
    "color": "yellow"
  },
  {
    "id": 2,
    "creationDate": "2024-07-06T10:15:00Z",
    "phoneNumber": "0987654321",
    "governorate": "Governorate2",
    "city": "City2",
    "district": "District2",
    "isHandled": false,
    "color": "green"
  }
]
