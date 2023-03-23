namespace VideoManagementApi.Models;

public abstract class Seo : BaseEntity
{
    public string Tag { get; set; }
    public string Description { get; set; }
    public int VideoId { get; set; }
    public Video Video { get; set; }
}