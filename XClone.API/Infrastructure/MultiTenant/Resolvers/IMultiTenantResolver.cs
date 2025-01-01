using XCloneModels.Constants;

namespace WebApplication1.Infrastructure.MultiTenant.Resolvers;

public interface IMultiTenantResolver
{
    public static string TenantIdKey => MultiTenantConstants.TenantId;
    
    string Resolve();

}