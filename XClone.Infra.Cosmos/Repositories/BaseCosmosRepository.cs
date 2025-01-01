using Microsoft.Azure.Cosmos;
using XClone.Application.Repositories;
using XClone.Infra.Cosmos.Extensions;

namespace XClone.Infra.Cosmos.Repositories;

public class BaseCosmosRepository(CosmosClient cosmosClient, string databaseName, string containerName):ICosmosRepository
{
    private readonly Container container = cosmosClient.GetContainer(databaseName, containerName);
    
    public virtual Task<ItemResponse<T>> UpSert<T>(T value ,string tenantId,CancellationToken cancellationToken = default)
    { 
        return container.UpsertItemAsync(value, tenantId.ToPartitionKey(), cancellationToken: cancellationToken);
    }
    
    public virtual Task<ItemResponse<T>> Delete<T>(string id, string tenantId, CancellationToken cancellationToken = default)
    {
        return container.DeleteItemAsync<T>(id, new PartitionKey(tenantId), cancellationToken: cancellationToken);
    }
    
    public virtual async Task<T> GetItemById<T>(string id, string tenantId, CancellationToken cancellationToken = default)
    {
        using var streamResponse = await container.ReadItemStreamAsync(id, tenantId.ToPartitionKey());
        // container.ReadItemAsync<T>(id, tenantId.ToPartitionKey(), cancellationToken: cancellationToken); null olursa hata durumunu kontrol etmek için streamResponse kullanıldı.
        if (streamResponse is {StatusCode: System.Net.HttpStatusCode.OK})
        {
            var cacheModel = cosmosClient.ClientOptions.Serializer.FromStream<T>(streamResponse.Content);
            return cacheModel;
        }
        
        return default;
    }
    
}