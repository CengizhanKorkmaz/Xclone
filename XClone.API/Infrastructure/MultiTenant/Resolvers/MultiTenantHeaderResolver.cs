using XCloneModels.Constants;

namespace WebApplication1.Infrastructure.MultiTenant.Resolvers;

public class MultiTenantHeaderResolver(IHttpContextAccessor httpContextAccessor) : IMultiTenantResolver
{
    public string Resolve()
    {
        return httpContextAccessor.HttpContext.Request?.Headers[MultiTenantConstants.TenantId];
    }
}