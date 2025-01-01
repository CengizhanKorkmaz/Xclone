using Mediator;
using XClone.Application.Extensions;
using XClone.Application.Services;
using XClone.Infra.SqlServer.Context;
using XCloneModels.Paging;
using XCloneModels.Queries.Feed;

namespace XClone.Application.Features.Queries;

public class GetUserFeedQueryHandler(XCloneDbContext context, ITenantMappingService tenantMappingService)
    : IRequestHandler<GetUserFeedQuery, PagedResponse<GetUserFeedViewModel>>
{
    public async ValueTask<PagedResponse<GetUserFeedViewModel>> Handle(GetUserFeedQuery request, CancellationToken cancellationToken)
    {
        var tenantUserId = tenantMappingService.GetUserByTenantId(request.TenantId);
        

        var feed = await context.Follows
            .Where(f => f.FollowerUserId == tenantUserId)
            .SelectMany(f => f.FollowingUser.Tweets)
            .OrderBy(i => i.CreatedDate)
            .Select(t => new GetUserFeedViewModel()
            {
                Id = t.Id,
                Content = t.Content,
                UserId = t.UserId,
                UserName = t.User.UserName,
                LikesCount = t.Likes.Count,
                IsLiked = t.Likes.Any(l => l.UserId == tenantUserId),
                ViewCount = t.ViewCount,
                CreatedAt = t.CreatedDate.DateTime

            })
            .GetPage(request.PageNumber, request.PageSize);

        return feed;
    }
}