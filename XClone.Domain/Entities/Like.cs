namespace XClone.Domain.Entities;

public class Like : BaseEntity
{
    public Guid UserId { get; set; }
    public Guid TweetId { get; set; }
    public Tweet Tweet { get; set; }
    public User User { get; set; }
}