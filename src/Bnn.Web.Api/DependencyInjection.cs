using Bnn.Services.Bananas;
using Bnn.Web.Api.Infrastructure;

namespace Bnn.Web.Api;

internal static class DependencyInjection
{
    public static IServiceCollection AddPresentation(this IServiceCollection services)
    {
        services.AddEndpointsApiExplorer();

        services.AddOpenApi();
        
        services.AddExceptionHandler<GlobalExceptionHandler>();
        services.AddProblemDetails();
        
        

        return services;
    }
}