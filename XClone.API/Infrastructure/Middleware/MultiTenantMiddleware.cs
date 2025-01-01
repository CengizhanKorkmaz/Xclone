using WebApplication1.Infrastructure.MultiTenant.Resolvers;
using WebApplication1.Infrastructure.MultiTenant.Services;

namespace WebApplication1.Infrastructure.Middleware;

public class MultiTenantMiddleware(IEnumerable<IMultiTenantResolver> resolvers):IMiddleware
{
    public Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        var multiTenantService = context.RequestServices.GetRequiredService<IMultiTenantService>();
        foreach (var resolve in resolvers)
        {
            var tenantId = resolve.Resolve();
            if (string.IsNullOrEmpty(tenantId))
                continue;
            multiTenantService.SetCurrentTenantId(tenantId);
            return next(context);
        }

        context.Response.StatusCode = StatusCodes.Status400BadRequest;
        return context.Response.WriteAsync("No tenant found");

    }
}