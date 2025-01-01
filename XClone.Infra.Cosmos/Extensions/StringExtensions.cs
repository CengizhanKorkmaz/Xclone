
using Microsoft.Azure.Cosmos;

namespace XClone.Infra.Cosmos.Extensions;

public static class StringExtensions
{
    public static PartitionKey ToPartitionKey(this string id)
    {
        return new PartitionKey(id);
    }
    
}