# Album Register

ASP.NET Core 9.0 MVC web application for managing an album collection.

## Prerequisites

- [.NET 9.0 SDK](https://dotnet.microsoft.com/download/dotnet/9.0)

## Running the Application

1. Create the database:
   ```bash
   dotnet ef database update
   ```

2. Run the application:
   ```bash
   dotnet run
   ```

3. Open your browser and navigate to `https://localhost:7039` or `http://localhost:5267`

The database will be seeded automatically with initial data on first run.

## Technologies

- ASP.NET Core 9.0 MVC
- Entity Framework Core
- SQLite
- Bootstrap 5
