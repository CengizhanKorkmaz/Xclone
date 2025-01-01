using XCloneModels.Constants;

namespace WebApplication1.Infrastructure.MultiTenant.Resolvers;

public class MultiTenantCookieResolver(IHttpContextAccessor httpContextAccessor) : IMultiTenantResolver
{
    public string Resolve()
    {
        return httpContextAccessor.HttpContext.Request?.Cookies[MultiTenantConstants.TenantId];
    }
}

public class MultiTenantUrlQueryStringResolver(IHttpContextAccessor httpContextAccessor) : IMultiTenantResolver
{
    public string Resolve()
    {
        return httpContextAccessor.HttpContext.Request?.Query[MultiTenantConstants.TenantId];
    }
}