namespace XClone.Domain.Entities;

public class Follow: BaseEntity
{
    public Guid FollowingUserId { get; set; }
    public Guid FollowerUserId { get; set; }
    public User FollowingUser { get; set; }
    public User FollowerUser { get; set; }
}