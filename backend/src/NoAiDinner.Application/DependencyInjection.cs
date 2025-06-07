using Microsoft.Extensions.DependencyInjection;
using NoAiDinner.Application.Services.Authentication;

namespace NoAiDinner.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IAuthenticationService, AuthenticationService>();

        return services;
    }
}