using VideoManagementApi.Models;

namespace VideoManagementApi.Dtos.VideoDtos;

public class VideoDto
{
    public string Title { get; set; }
    public string Description { get; set; }
    public string FilePath { get; set; }
    public string FileName { get; set; }
    public int WatchCount { get; set; }
    public ICollection<Seo> Seos { get; set; }
    public ICollection<Like> Likes { get; set; }
    public ICollection<Comment> Comments { get; set; }
    public ICollection<VideoAndCategory> VideoAndCategories { get; set; }
}