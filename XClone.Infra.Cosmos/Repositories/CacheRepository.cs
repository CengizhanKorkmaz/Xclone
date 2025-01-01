using Microsoft.Azure.Cosmos;
using XClone.Application.Repositories;
using XCloneModels.Constants;

namespace XClone.Infra.Cosmos.Repositories;

internal class CacheRepository(CosmosClient cosmosClient):BaseCosmosRepository(cosmosClient,CosmosConstants.CacheDbName,CosmosConstants.FeedCacheContainerName),ICacheRepository
{
    
    
}