# Code Review Guidelines

This document provides comprehensive guidelines for conducting code reviews in the Employee Service API project. These guidelines ensure code quality, maintainability, security, and consistency across the codebase.

## Table of Contents

- [General Principles](#general-principles)
- [ASP.NET Core & Web API Guidelines](#aspnet-core--web-api-guidelines)
- [Entity Framework Core Guidelines](#entity-framework-core-guidelines)
- [Security Guidelines](#security-guidelines)
- [Performance Guidelines](#performance-guidelines)
- [Testing Guidelines](#testing-guidelines)
- [Code Style & Formatting](#code-style--formatting)
- [Documentation Standards](#documentation-standards)
- [Review Process](#review-process)

## General Principles

### Code Quality
- ✅ **DO** ensure code is readable, maintainable, and follows established patterns
- ✅ **DO** verify that code changes solve the intended problem
- ✅ **DO** check that new functionality doesn't break existing features
- ❌ **DON'T** approve code that introduces technical debt without justification
- ❌ **DON'T** merge code with TODO comments unless they're tracked in issues

### Architecture & Design
- ✅ **DO** ensure adherence to SOLID principles
- ✅ **DO** verify proper separation of concerns (Controllers, Data Access, Models)
- ✅ **DO** check for appropriate use of dependency injection
- ✅ **DO** ensure interface contracts are properly implemented
- ❌ **DON'T** allow tight coupling between layers

## ASP.NET Core & Web API Guidelines

### Controller Best Practices
- ✅ **DO** verify controllers are lightweight and delegate business logic to services
- ✅ **DO** ensure proper HTTP status codes are returned (200, 201, 400, 404, 500)
- ✅ **DO** check for consistent API endpoint naming conventions (`/api/[controller]`)
- ✅ **DO** verify proper use of HTTP verbs (GET, POST, PUT, DELETE)
- ✅ **DO** ensure proper model validation using Data Annotations
- ❌ **DON'T** allow business logic in controllers
- ❌ **DON'T** permit hardcoded values in controller actions

### Example - Good Controller Pattern:
```csharp
[HttpGet("{id}")]
public async Task<ActionResult<Employee>> GetEmployee(int id)
{
    var employee = await _dataAccess.GetByIdAsync(id);
    if (employee is null)
        return NotFound();
    return Ok(employee);
}
```

### Async/Await Patterns
- ✅ **DO** ensure all database operations use async/await
- ✅ **DO** verify ConfigureAwait(false) is used in library code when appropriate
- ✅ **DO** check that async methods have proper naming (suffix with "Async")
- ❌ **DON'T** allow synchronous database calls in async contexts
- ❌ **DON'T** permit async void methods (except event handlers)

## Entity Framework Core Guidelines

### DbContext Management
- ✅ **DO** ensure DbContext is properly registered with DI container
- ✅ **DO** verify connection strings are stored in configuration
- ✅ **DO** check for proper disposal of DbContext (handled by DI)
- ❌ **DON'T** allow direct instantiation of DbContext in business logic

### Data Access Patterns
- ✅ **DO** verify use of repository pattern or data access interfaces
- ✅ **DO** ensure proper error handling for database operations
- ✅ **DO** check for appropriate use of tracking vs. no-tracking queries
- ✅ **DO** verify proper handling of null return values
- ❌ **DON'T** allow direct DbContext usage in controllers

### Example - Good Data Access Pattern:
```csharp
public async Task<Employee?> GetByIdAsync(int id)
{
    return await _context.Employees
        .AsNoTracking()
        .FirstOrDefaultAsync(e => e.Id == id);
}
```

### Migrations
- ✅ **DO** review migration files for correctness
- ✅ **DO** ensure migrations are additive and don't lose data
- ✅ **DO** verify proper naming conventions for migrations
- ❌ **DON'T** allow manual edits to generated migration files without review

## Security Guidelines

### Input Validation
- ✅ **DO** verify all user inputs are validated
- ✅ **DO** ensure proper use of Data Annotations for validation
- ✅ **DO** check for SQL injection prevention (parameterized queries)
- ✅ **DO** verify XSS prevention measures
- ❌ **DON'T** allow raw SQL queries without proper parameterization

### Authentication & Authorization
- ✅ **DO** verify proper authentication mechanisms are in place
- ✅ **DO** ensure authorization attributes are used where needed
- ✅ **DO** check for secure storage of connection strings and secrets
- ❌ **DON'T** allow credentials or secrets in source code

### Error Handling
- ✅ **DO** ensure sensitive information is not exposed in error messages
- ✅ **DO** verify proper logging of errors without exposing internal details
- ✅ **DO** check for global exception handling
- ❌ **DON'T** allow stack traces to be exposed to end users

## Performance Guidelines

### Database Performance
- ✅ **DO** verify efficient LINQ queries (avoid N+1 problems)
- ✅ **DO** check for appropriate use of Include() for related data
- ✅ **DO** ensure proper indexing considerations
- ✅ **DO** verify pagination for large datasets
- ❌ **DON'T** allow SELECT * queries or loading unnecessary data

### Memory Management
- ✅ **DO** check for proper disposal of resources
- ✅ **DO** verify appropriate use of async/await to prevent blocking
- ✅ **DO** ensure large objects are properly handled
- ❌ **DON'T** allow memory leaks or resource leaks

### Example - Efficient Query:
```csharp
public async Task<IEnumerable<Employee>> GetBySalaryRangeAsync(decimal min, decimal max)
{
    return await _context.Employees
        .AsNoTracking()
        .Where(e => e.Salary >= min && e.Salary <= max)
        .ToListAsync();
}
```

## Testing Guidelines

### Unit Tests
- ✅ **DO** verify that new code has appropriate unit test coverage
- ✅ **DO** ensure tests are independent and can run in any order
- ✅ **DO** check for proper mocking of dependencies
- ✅ **DO** verify test names clearly describe what is being tested
- ❌ **DON'T** allow tests that depend on external resources

### Integration Tests
- ✅ **DO** verify API endpoints work correctly end-to-end
- ✅ **DO** ensure database integration tests use test databases
- ✅ **DO** check for proper cleanup after integration tests
- ❌ **DON'T** allow integration tests to pollute production data

### Test Structure
```csharp
[Test]
public async Task GetEmployee_WithValidId_ReturnsEmployee()
{
    // Arrange
    var expectedEmployee = new Employee { Id = 1, Ename = "John" };
    
    // Act
    var result = await _controller.GetEmployee(1);
    
    // Assert
    Assert.That(result.Value, Is.EqualTo(expectedEmployee));
}
```

## Code Style & Formatting

### C# Conventions
- ✅ **DO** follow Microsoft's C# coding conventions
- ✅ **DO** use PascalCase for public members and classes
- ✅ **DO** use camelCase for private fields and local variables
- ✅ **DO** ensure consistent indentation (4 spaces)
- ✅ **DO** verify proper use of var keyword
- ❌ **DON'T** allow inconsistent naming conventions

### File Organization
- ✅ **DO** ensure proper namespace organization
- ✅ **DO** verify appropriate using statement organization
- ✅ **DO** check for one class per file
- ✅ **DO** ensure files are placed in appropriate folders
- ❌ **DON'T** allow unused using statements

### Comments & Documentation
- ✅ **DO** ensure complex logic is properly commented
- ✅ **DO** verify XML documentation for public APIs
- ✅ **DO** check that comments add value and explain "why" not "what"
- ❌ **DON'T** allow outdated or misleading comments

## Documentation Standards

### API Documentation
- ✅ **DO** ensure Swagger/OpenAPI documentation is complete
- ✅ **DO** verify example requests and responses are provided
- ✅ **DO** check that error responses are documented
- ❌ **DON'T** allow undocumented public endpoints

### Code Documentation
- ✅ **DO** ensure public methods have XML documentation
- ✅ **DO** verify README updates for new features
- ✅ **DO** check that complex algorithms are explained
- ❌ **DON'T** allow missing documentation for public APIs

### Example - Good XML Documentation:
```csharp
/// <summary>
/// Retrieves an employee by their unique identifier.
/// </summary>
/// <param name="id">The unique identifier of the employee.</param>
/// <returns>The employee if found, otherwise null.</returns>
public async Task<Employee?> GetByIdAsync(int id)
```

## Review Process

### Before Submitting PR
- ✅ **DO** ensure code builds without warnings
- ✅ **DO** run all existing tests and verify they pass
- ✅ **DO** test the changes manually
- ✅ **DO** update documentation if needed
- ❌ **DON'T** submit untested code

### During Review
- ✅ **DO** review for functionality, not just syntax
- ✅ **DO** check for edge cases and error handling
- ✅ **DO** verify performance implications
- ✅ **DO** ensure security considerations are addressed
- ✅ **DO** provide constructive feedback
- ❌ **DON'T** approve without understanding the changes
- ❌ **DON'T** focus solely on style issues

### Review Checklist
- [ ] Code builds successfully
- [ ] All tests pass
- [ ] Follows established patterns
- [ ] Proper error handling
- [ ] Security considerations addressed
- [ ] Performance acceptable
- [ ] Documentation updated
- [ ] No hardcoded values
- [ ] Proper async/await usage
- [ ] Database queries are efficient

### Common Issues to Watch For
- Missing null checks
- Improper exception handling
- Synchronous database calls
- Exposed sensitive information
- Missing input validation
- Resource leaks
- Inconsistent error responses
- Missing or incorrect HTTP status codes

## Conclusion

These guidelines ensure that the Employee Service API maintains high code quality, security, and performance standards. All team members should familiarize themselves with these guidelines and apply them consistently during code reviews.

For questions about these guidelines or specific review scenarios, please consult with the team lead or create an issue for discussion.