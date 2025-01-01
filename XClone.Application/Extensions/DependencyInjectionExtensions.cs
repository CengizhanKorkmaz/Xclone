using Mapster;
using Mediator;
using Microsoft.Extensions.DependencyInjection;
using XClone.Application.Infrastructure.PipelineBehaviours;

namespace XClone.Application.Extensions;

public static class DependencyInjectionExtensions
{
    public static IServiceCollection AddApplicationsServices(this IServiceCollection services)
    {
        services.AddMediator(opt =>
        {
            opt.ServiceLifetime = ServiceLifetime.Scoped;
        });
        services.AddMapster();
        
        services.AddTransient(typeof(IPipelineBehavior<,>),typeof(TenantCachePipelineBehaviour<,>));

        return services;
    }
    
}