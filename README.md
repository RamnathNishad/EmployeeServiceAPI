# Employee Service API

A RESTful API service for managing employee data built with ASP.NET Core 8.0 and Entity Framework Core.

## Overview

The Employee Service API provides a comprehensive set of endpoints for managing employee records in a SQL Server database. It follows RESTful principles and includes features such as:

- CRUD operations for employee records
- Swagger/OpenAPI documentation
- Entity Framework Core for data access
- Dependency injection for better testability
- Asynchronous operations for improved performance

## Getting Started

### Prerequisites

- .NET 8.0 SDK or later
- SQL Server (Local or Remote)
- Visual Studio 2022 or VS Code

### Configuration

1. Update the connection string in `appsettings.json`:
```json
{
  "ConnectionStrings": {
    "EmployeeDb": "your_connection_string_here"
  }
}
```

2. Run Entity Framework migrations:
```powershell
dotnet ef database update
```

### Running the Application

1. Clone the repository
2. Navigate to the project directory
3. Run the application:
```powershell
dotnet run
```

The API will be available at:
- HTTP: http://localhost:5000
- HTTPS: https://localhost:5001
- Swagger UI: https://localhost:5001/swagger

## Documentation

- [Usage Examples](./UsageExamples.md) - Detailed examples of API usage
- [Changelog](./ChangeLog.md) - Version history and changes
- [Code Review Guidelines](./REVIEW_GUIDELINES.md) - Standards and best practices for code reviews

## API Endpoints

### Employee Controller (`/api/employees`)

| Method | Endpoint | Description |
|--------|----------|-------------|
| GET | `/api/employees` | Get all employees |
| GET | `/api/employees/{id}` | Get employee by ID |
| POST | `/api/employees` | Create new employee |
| PUT | `/api/employees/{id}` | Update employee |
| DELETE | `/api/employees/{id}` | Delete employee |

## Project Structure

- `Controllers/` - API endpoints and request handling
  - [`EmployeesController.cs`](./Controllers/EmployeesController.cs) - Main API controller
- `Models/` - Data models and DTOs
  - [`Employee.cs`](./Models/Employee.cs) - Employee entity model
- `Data/` - Data access and database context
  - [`EmployeeDbContext.cs`](./Data/EmployeeDbContext.cs) - EF Core DB context
  - [`IEmployeeDataAccess.cs`](./Data/IEmployeeDataAccess.cs) - Data access interface
  - [`EmployeeDataAccess.cs`](./Data/EmployeeDataAccess.cs) - Data access implementation

## License

This project is licensed under the MIT License.
