using Mediator;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Infrastructure.Middleware;
using XClone.Application.Features.Queries;
using XCloneModels.Helpers;


namespace WebApplication1.Infrastructure.EndPoints.RequestHandlers;

public static class FeedEndPoints
{
    public static void RegisterFeedMappings(this WebApplication app)
    {
         
        app.MapGet("feed".AdjustTenantRoute(),HandleFeed).AddEndpointFilter<MultiTenantIdEndpointFilter>();
    }
    private static async Task<IResult> HandleFeed(HttpContext httpContext,[FromServices] IMediator mediator,[AsParameters] GetUserFeedQuery query)
    {
        
        var res = await mediator.Send(query);
        return Results.Ok(res);
    }
    
}