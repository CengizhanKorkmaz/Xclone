using WebApplication1.Infrastructure.MultiTenant.Services;
using XClone.Application.Infrastructure.Models.MultiTenant;

namespace WebApplication1.Infrastructure.Middleware;

public class MultiTenantIdEndpointFilter(IMultiTenantService multiTenantService):IEndpointFilter
{
    public async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
    {
        var currentTenantId = multiTenantService.GetCurrentTenantId();
        foreach (var argument in context.Arguments)
        {
            if (argument is IMultiTenant multiTenantArg)
            {
                multiTenantArg.TenantId = currentTenantId;
            }
            
        }
        return await next(context);
    }
}