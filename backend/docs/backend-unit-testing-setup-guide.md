# Backend Unit Testing Setup Guide

## Create Unit Test Projects

### From root directory:

```bash
# Create unit test projects for each layer
dotnet new xunit -o backend/tests/NoAiDinner.Domain.Tests
dotnet new xunit -o backend/tests/NoAiDinner.Application.Tests
dotnet new xunit -o backend/tests/NoAiDinner.Infrastructure.Tests
dotnet new xunit -o backend/tests/NoAiDinner.Api.Tests
```

## Add Test Projects to Solution

```bash
# Add all test projects to solution
dotnet sln backend/NoAiDinner.sln add backend/tests/**/*.csproj
```

## Add Project References

```bash
# Domain Tests - only references Domain
dotnet add backend/tests/NoAiDinner.Domain.Tests/ reference backend/src/NoAiDinner.Domain/

# Application Tests - references Application and Domain
dotnet add backend/tests/NoAiDinner.Application.Tests/ reference backend/src/NoAiDinner.Application/ backend/src/NoAiDinner.Domain/

# Infrastructure Tests - references Infrastructure, Application and Domain
dotnet add backend/tests/NoAiDinner.Infrastructure.Tests/ reference backend/src/NoAiDinner.Infrastructure/ backend/src/NoAiDinner.Application/ backend/src/NoAiDinner.Domain/

# API Tests - references API project
dotnet add backend/tests/NoAiDinner.Api.Tests/ reference backend/src/NoAiDinner.Api/
```

## Add Testing Packages

```bash
# Add mocking framework for unit tests
dotnet add backend/tests/NoAiDinner.Application.Tests/ package Moq
dotnet add backend/tests/NoAiDinner.Infrastructure.Tests/ package Moq

# Add in-memory database for Infrastructure tests
dotnet add backend/tests/NoAiDinner.Infrastructure.Tests/ package Microsoft.EntityFrameworkCore.InMemory

# Add testing utilities for API tests
dotnet add backend/tests/NoAiDinner.Api.Tests/ package Microsoft.AspNetCore.Mvc.Testing
```

## Run Tests

```bash
# Run all unit tests from root
dotnet test backend/

# Run specific test project
dotnet test backend/tests/NoAiDinner.Domain.Tests/

# Run tests with coverage
dotnet test backend/ --collect:"XPlat Code Coverage"
```

## What to Test

- **Domain Tests**: Entity behavior, business rules, value objects
- **Application Tests**: Use case logic, service behavior (with mocked dependencies)
- **Infrastructure Tests**: Repository patterns, database operations (with in-memory DB)
- **API Tests**: Controller logic, request/response handling (with mocked services)
