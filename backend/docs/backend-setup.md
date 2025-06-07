# Backend Setup for NoAiDinner

**Create base folders:**

```bash
# Create backend folder structure
mkdir backend

# Create backend subfolders for organization
mkdir backend/docs
mkdir backend/src
mkdir backend/tests

# Create backend documentation file
touch backend/docs/backend-docs.md

# Create frontend folder structure
mkdir frontend

# Create frontend documentation folder
mkdir frontend/docs

# Create frontend documentation file
touch frontend/docs/frontend-docs.md
```

<hr>

**Create a new solution**

```bash
dotnet new sln --output backend --name NoAiDinner
```

<hr>

**Create a new Web API project**

```bash
dotnet new webapi --name NoAiDinner.Api --output backend/src/NoAiDinner.Api
```

<hr>

**Add classlibrary projects**:
This step is essential to create the necessary class libraries for the backend architecture.

```bash
dotnet new classlib -o backend/src/NoAiDinner.Contracts
dotnet new classlib -o backend/src/NoAiDinner.Infrastructure
dotnet new classlib -o backend/src/NoAiDinner.Domain
dotnet new classlib -o backend/src/NoAiDinner.Application
```

**Add the projects to the solution**
This step is necessary to ensure that all projects are part of the solution and can be built together.

```bash
dotnet sln backend/NoAiDinner.sln add $(find backend/src -name "*.csproj")
```

<hr>

**Add project references**:
This step is crucial for ensuring that the projects can reference each other correctly.

```bash
# API layer references (all in one line)
dotnet add backend/src/NoAiDinner.Api/ reference backend/src/NoAiDinner.Contracts/ backend/src/NoAiDinner.Application/ backend/src/NoAiDinner.Infrastructure/

# Infrastructure layer references
dotnet add backend/src/NoAiDinner.Infrastructure/ reference backend/src/NoAiDinner.Application/

# Application layer references
dotnet add backend/src/NoAiDinner.Application/ reference backend/src/NoAiDinner.Domain/ backend/src/NoAiDinner.Contracts/
```

<hr>

**Add Controller folder:**
This is where you will place your API controllers.

```bash
mkdir backend/src/NoAiDinner.Api/Controllers
```

<hr>

**Clean program.cs:**
This is to remove the default template code and prepare for custom configuration.

```cs
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Services.AddControllers();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.MapControllers();

app.Run();
```
