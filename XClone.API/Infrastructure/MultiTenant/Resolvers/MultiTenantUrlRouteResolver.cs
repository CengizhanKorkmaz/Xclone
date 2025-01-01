using XCloneModels.Constants;

namespace WebApplication1.Infrastructure.MultiTenant.Resolvers;

public class MultiTenantUrlRouteResolver(IHttpContextAccessor httpContextAccessor) : IMultiTenantResolver
{
    public string Resolve()
    {
        return httpContextAccessor.HttpContext.Request?.RouteValues[MultiTenantConstants.TenantId]?.ToString();
    }
}