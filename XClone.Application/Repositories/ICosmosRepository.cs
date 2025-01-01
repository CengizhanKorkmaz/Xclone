using Microsoft.Azure.Cosmos;

namespace XClone.Application.Repositories;

public interface ICosmosRepository
{
    Task<ItemResponse<T>> UpSert<T>(T value, string tenantI,CancellationToken cancellationToken = default);
    Task<ItemResponse<T>> Delete<T>(string id, string tenantId, CancellationToken cancellationToken = default);
    Task<T> GetItemById<T>(string id, string tenantId, CancellationToken cancellationToken = default);
}