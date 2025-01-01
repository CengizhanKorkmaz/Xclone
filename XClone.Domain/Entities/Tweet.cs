namespace XClone.Domain.Entities;

public class Tweet : BaseEntity
{
    public Guid UserId { get; set; }
    public string Content { get; set; }
    public int ViewCount { get; set; }
    public User User { get; set; }
    public ICollection<Like> Likes { get; set; }
}