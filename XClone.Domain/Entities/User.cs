using System.ComponentModel.DataAnnotations.Schema;

namespace XClone.Domain.Entities;

public class User : BaseEntity
{
    public string UserName { get; set; }
    public string EmailAddress { get; set; }
    public string Password { get; set; }

    public ICollection<Like> Likes { get; set; }
    public ICollection<Tweet> Tweets { get; set; }
    [InverseProperty(nameof(Follow.FollowerUserId))]
    public ICollection<Follow> Followers { get; set; }
    [InverseProperty(nameof(Follow.FollowingUserId))]
    public ICollection<Follow> Followings { get; set; }

    public TenantMapping? TenantMapping { get; set; }
}