using System.Text.Json.Serialization;
using XCloneModels.Paging;
using XCloneModels.Queries.Feed;

namespace WebApplication1.Infrastructure.SourceGenerator;

[JsonSerializable(typeof(PagedResponse<GetUserFeedViewModel>))]
[JsonSourceGenerationOptions(WriteIndented = true)]
public partial class JsonSerializerContext: System.Text.Json.Serialization.JsonSerializerContext
{
    
}