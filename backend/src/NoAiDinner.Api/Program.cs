using NoAiDinner.Application;
using NoAiDinner.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddOpenApi();
    builder.Services.AddControllers();

    // Register Clean Architecture layer services
    builder.Services
        .AddApplication()
        .AddInfrastructure();
}

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.MapControllers();

app.Run();