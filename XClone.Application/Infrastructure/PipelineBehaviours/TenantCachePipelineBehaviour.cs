using Mediator;
using XClone.Application.Infrastructure.Models.Interfaces;
using XClone.Application.Services;

namespace XClone.Application.Infrastructure.PipelineBehaviours;

public class TenantCachePipelineBehaviour<TRequest, TResponse>(ITenantCacheService tenantCacheService)
    : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TRequest>, ITenantCacheable
    where TResponse : class
{

    public async ValueTask<TResponse> Handle(TRequest message, MessageHandlerDelegate<TRequest, TResponse> next, CancellationToken cancellationToken)
    {

        if (message.IgnoreCacheRead is false)
        {
            var cachedValue = await tenantCacheService.GetCache<TResponse>(message.TenantId, message.CacheKey);
            if (cachedValue is not null)
                return cachedValue;
        }

        var response = await next(message, cancellationToken);

        if (message.IgnoreCacheWrite is false && response is not null)
        {
            await tenantCacheService.SetCache(message.TenantId, message.CacheKey, response);
        }

        return response;

    }
}
