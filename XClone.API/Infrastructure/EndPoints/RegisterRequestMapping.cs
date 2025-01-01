using WebApplication1.Infrastructure.EndPoints.RequestHandlers;

namespace WebApplication1.Infrastructure.EndPoints;

public  static class RegisterRequestMapping
{
    public static void RegisterMappings(this WebApplication application)
    {
        FeedEndPoints.RegisterFeedMappings(application);
    }
}