# TicketSystem.Backend
# TicketSystem

TicketSystem is a .NET Core application for managing tickets using CQRS, MediatR, and Repository Pattern.

## Table of Contents

1. [Overview](#overview)
2. [Features Implemented](#features-implemented)
3. [Design Patterns](#design-patterns)
4. [Technologies Used](#technologies-used)
5. [Setup and Configuration](#setup-and-configuration)
6. [Running the Application](#running-the-application)
7. [Example Usage](#example-usage)
8. [Future Improvements](#future-improvements)
9. [Contributors](#contributors)
10. [License](#license)

## Overview

TicketSystem is designed to manage tickets with CRUD operations and includes features like handling overdue tickets automatically.

## Features Implemented

- **CQRS and MediatR**: Commands and queries are separated, enhancing application structure.
- **Repository Pattern**: Data access layer abstraction using interfaces for repositories.
- **Background Service**: Automatic handling of overdue tickets using a background service.
- **Static Data Endpoints**: APIs to retrieve lists of governorates, cities, and districts.

## Design Patterns

- **Repository Pattern**: Provides a consistent way to access and manipulate data.
- **Unit of Work**: Manages transactions across multiple repository operations.
- **MediatR and CQRS**: Encourages separation of concerns by handling commands and queries independently.

## Technologies Used

- ASP.NET Core
- Entity Framework Core
- MediatR
- AutoMapper

## Setup and Configuration

1. **Database Configuration**: Update the database connection string in `appsettings.json`.
2. **Dependency Injection**: Configure services and dependencies in `Startup.cs`.
3. **AutoMapper Configuration**: Define AutoMapper profiles for mapping DTOs to domain models.

## Running the Application

To run the TicketSystem locally:

1. Clone the repository: `git clone https://github.com/yourusername/TicketSystem.git`
2. Navigate to the project directory: `cd TicketSystem`
3. Restore dependencies: `dotnet restore`
4. Update database: `dotnet ef database update`
5. Start the application: `dotnet run`

## Example Usage

### Creating a Ticket

To create a ticket, send a POST request to `/api/tickets` with JSON body:

```json
{
  "phoneNumber": "123456789",
  "governorate": "Governorate1",
  "city": "City1",
  "district": "District1"
}
