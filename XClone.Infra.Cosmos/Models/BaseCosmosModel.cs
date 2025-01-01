namespace XClone.Infra.Cosmos.Models;

public record BaseCosmosModel<T>
{
    [Newtonsoft.Json.JsonProperty(PropertyName = "id")]
    public string  Id { get; set; } = Guid.NewGuid().ToString();

    [Newtonsoft.Json.JsonProperty(PropertyName = "tenantid")]
    public string TenantId{ get; set; }
    
    public T Value { get; set; }
    
}