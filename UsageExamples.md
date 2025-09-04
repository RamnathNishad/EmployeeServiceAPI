# Usage Examples

This document provides detailed examples of how to use the Employee Service API endpoints.

## Table of Contents
- [Authentication](#authentication)
- [Retrieving Employees](#retrieving-employees)
- [Creating Employees](#creating-employees)
- [Updating Employees](#updating-employees)
- [Deleting Employees](#deleting-employees)

## Authentication

Currently, the API does not require authentication. All endpoints are publicly accessible.

## Retrieving Employees

### Get All Employees

```http
GET /api/employees
```

Example Response:
```json
[
  {
    "id": 1,
    "ename": "John Doe",
    "salary": 75000.00,
    "deptid": 100
  },
  {
    "id": 2,
    "ename": "Jane Smith",
    "salary": 85000.00,
    "deptid": 101
  }
]
```

### Get Employee by ID

```http
GET /api/employees/1
```

Example Response:
```json
{
  "id": 1,
  "ename": "John Doe",
  "salary": 75000.00,
  "deptid": 100
}
```

## Creating Employees

### Create New Employee

```http
POST /api/employees
Content-Type: application/json

{
  "ename": "New Employee",
  "salary": 65000.00,
  "deptid": 102
}
```

Example Response:
```json
{
  "id": 3,
  "ename": "New Employee",
  "salary": 65000.00,
  "deptid": 102
}
```

## Updating Employees

### Update Existing Employee

```http
PUT /api/employees/3
Content-Type: application/json

{
  "id": 3,
  "ename": "Updated Employee",
  "salary": 70000.00,
  "deptid": 102
}
```

Example Response:
```json
{
  "id": 3,
  "ename": "Updated Employee",
  "salary": 70000.00,
  "deptid": 102
}
```

## Deleting Employees

### Delete Employee

```http
DELETE /api/employees/3
```

Success Response: HTTP 204 No Content

## Using with Different Tools

### cURL Examples

Get all employees:
```bash
curl -X GET https://localhost:5001/api/employees
```

Create new employee:
```bash
curl -X POST https://localhost:5001/api/employees \
  -H "Content-Type: application/json" \
  -d '{"ename":"New Employee","salary":65000.00,"deptid":102}'
```

### C# Client Example

```csharp
using System.Net.Http;
using System.Text.Json;

public class EmployeeApiClient
{
    private readonly HttpClient _client;
    private readonly string _baseUrl = "https://localhost:5001/api";

    public async Task<List<Employee>> GetEmployeesAsync()
    {
        var response = await _client.GetAsync($"{_baseUrl}/employees");
        response.EnsureSuccessStatusCode();
        var content = await response.Content.ReadAsStringAsync();
        return JsonSerializer.Deserialize<List<Employee>>(content);
    }
}
```

For more information about the API structure and setup, please refer to the [README.md](./README.md).
