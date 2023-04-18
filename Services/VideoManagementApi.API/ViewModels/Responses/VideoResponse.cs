using VideoManagementApi.Domain.Entities;

namespace VideoManagementApi.API.ViewModels.Responses;

public class VideoResponse
{
    public string Title { get; set; }
    public string Description { get; set; }
    public string FilePath { get; set; }
    public string FileName { get; set; }
    public int WatchCount { get; set; }
    public ICollection<SeoResponse> Seos { get; set; }
    public ICollection<LikesResponse> Likes { get; set; }
    public ICollection<CommentResponse> Comments { get; set; }
}