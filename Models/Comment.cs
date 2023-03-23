namespace VideoManagementApi.Models;

public abstract class Comment : BaseEntity
{
    public string IpAddress { get; set; }
    public string Name { get; set; }
    public string Content { get; set; }
    public int VideoId { get; set; }
    public Video Video { get; set; }
}