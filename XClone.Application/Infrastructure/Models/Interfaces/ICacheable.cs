namespace XClone.Application.Infrastructure.Models.Interfaces;

public interface ICacheable
{
    string CacheKey { get; }
    bool? IgnoreCacheRead { get;set; }
    bool? IgnoreCacheWrite { get;set; }
    
}