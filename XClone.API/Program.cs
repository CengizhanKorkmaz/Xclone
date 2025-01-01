using Microsoft.AspNetCore.Http.Json;
using WebApplication1.Infrastructure.EndPoints.RequestHandlers;
using WebApplication1.Infrastructure.MultiTenant.Extensions;
using WebApplication1.Infrastructure.MultiTenant.Services;
using WebApplication1.Infrastructure.SourceGenerator;
using XClone.Application.Extensions;
using XClone.Infra.Cosmos.Extensions;
using XClone.Infra.SqlServer.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMultiTenancy();
builder.Services.AddApplicationsServices();
builder.Services.AddInfraSqlServices(builder.Configuration.GetConnectionString("SqlServer"),(sp) =>
{
    var service = sp.GetRequiredService<IMultiTenantService>();
    return service.GetUserId().ToString()!;
});

builder.Services.AddInfraCosmosServices(builder.Configuration.GetConnectionString("CosmosDb"));
builder.Services.Configure<JsonOptions>(opt => opt.SerializerOptions.TypeInfoResolver = JsonSerializerContext.Default);
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.RegisterFeedMappings();
app.UseHttpsRedirection();
app.UseMultiTenancy();
app.Run();

namespace WebApplication1
{
    record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
    {
        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
    }
}