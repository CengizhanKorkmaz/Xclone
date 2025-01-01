using Microsoft.Extensions.DependencyInjection.Extensions;
using WebApplication1.Infrastructure.Middleware;
using WebApplication1.Infrastructure.MultiTenant.Options;
using WebApplication1.Infrastructure.MultiTenant.Resolvers;
using WebApplication1.Infrastructure.MultiTenant.Services;
using WebApplication1.Infrastructure.Services;
using XClone.Application.Services;

namespace WebApplication1.Infrastructure.MultiTenant.Extensions;

public static class MultiTenantExtensions
{
    public static IServiceCollection AddMultiTenancy(this IServiceCollection services, Action<MultiTenancyOptions> optAction)
    {
        services.AddHttpContextAccessor();
        services.AddSingleton<MultiTenantMiddleware>();
        services.AddScoped<IMultiTenantService, MultiTenantService>();
        services.AddSingleton<ITenantMappingService, TenantMappingService>();
        services.AddScoped<MultiTenantIdEndpointFilter>();
        var opt = new MultiTenancyOptions();
        optAction(opt);

        if (opt.InternalUseCookieResolver)
            services.TryAddEnumerable(ServiceDescriptor.Singleton<IMultiTenantResolver, MultiTenantCookieResolver>());
        if (opt.InternalUseHeaderResolver)
            services.TryAddEnumerable(ServiceDescriptor.Singleton<IMultiTenantResolver, MultiTenantHeaderResolver>());
        if (opt.InternalUseQueryStringResolver)
            services.TryAddEnumerable(ServiceDescriptor
                .Singleton<IMultiTenantResolver, MultiTenantUrlQueryStringResolver>());
        if (opt.InternalUseRouteResolver)
            services.TryAddEnumerable(ServiceDescriptor.Singleton<IMultiTenantResolver, MultiTenantUrlRouteResolver>());

        if (!opt.AtLeastOneActive)
            throw new Exception("No MultiResolver not found");

        return services;
    }

    public static IServiceCollection AddMultiTenancy(this IServiceCollection services)
    {
        AddMultiTenancy(services, opt =>
        {
            opt.UseCookieResolver()
                .UseHeaderResolver()
                .UseQueryStringResolver()
                .UseRouteResolver();
        });

        return services;
    }

    public static IApplicationBuilder UseMultiTenancy(this IApplicationBuilder app)
    {
        app.UseMiddleware<MultiTenantMiddleware>();
        return app;
    }
}