using XClone.Application.Features.Base;
using XCloneModels.Constants;
using XCloneModels.Paging;
using XCloneModels.Queries.Feed;

namespace XClone.Application.Features.Queries;

public class GetUserFeedQuery : CacheablePagedQuery<GetUserFeedViewModel>
{
  public override string CacheKey => Constants.CacheKeys.UserFeed;
}
