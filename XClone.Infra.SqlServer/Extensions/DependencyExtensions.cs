using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using XClone.Infra.SqlServer.Context;
using XCloneModels.Helpers;

namespace XClone.Infra.SqlServer.Extensions;

public static class DependencyExtensions
{
    public static IServiceCollection AddInfraSqlServices(this IServiceCollection services, string connectionString,
        GetTenantIdDelegate getTenantIdDelegate)
    {
        services.AddDbContext<TenantMappingContext>((sp, options) =>
        {
            var logger = sp.GetRequiredService<ILogger<TenantMappingContext>>();
            options.UseSqlServer(connectionString);
        });
        
        services.AddDbContext<XCloneDbContext>((sp, options) =>
        {
            var logger = sp.GetRequiredService<ILogger<XCloneDbContext>>();
            options.UseSqlServer(connectionString);

            options.EnableSensitiveDataLogging(sensitiveDataLoggingEnabled: true);
        });

        services.AddSingleton(getTenantIdDelegate);

        return services;

    }
    
}