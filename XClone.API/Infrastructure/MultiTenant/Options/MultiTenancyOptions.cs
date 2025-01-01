namespace WebApplication1.Infrastructure.MultiTenant.Options;

public class MultiTenancyOptions
{
    internal bool InternalUseCookieResolver { get; set; }
    internal bool InternalUseHeaderResolver { get; set; }
    internal bool InternalUseQueryStringResolver { get; set; }
    internal bool InternalUseRouteResolver { get; set; }
    
    public MultiTenancyOptions UseCookieResolver()
    {
        InternalUseCookieResolver = true;
        return this;
    }
    
    public MultiTenancyOptions UseHeaderResolver()
    {
        InternalUseHeaderResolver = true;
        return this;
    }
    
    public MultiTenancyOptions UseQueryStringResolver()
    {
        InternalUseQueryStringResolver = true;
        return this;
    }
    
    public MultiTenancyOptions UseRouteResolver()
    {
        InternalUseRouteResolver = true;
        return this;
    }
    
    public bool AtLeastOneActive => InternalUseCookieResolver || InternalUseHeaderResolver || InternalUseQueryStringResolver || InternalUseRouteResolver;
    
    
}