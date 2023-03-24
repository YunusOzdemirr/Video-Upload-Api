using VideoManagementApi.Dtos.CommentDtos;
using VideoManagementApi.Dtos.LikeDtos;
using VideoManagementApi.Dtos.SeoDtos;
using VideoManagementApi.Dtos.VideoAndCategoryDtos;
namespace VideoManagementApi.Dtos.VideoDtos;

public class VideoDto
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string FilePath { get; set; }
    public string FileName { get; set; }
    public int WatchCount { get; set; }
    public ICollection<SeoDto> Seos { get; set; }
    public ICollection<LikeDto> Likes { get; set; }
    public ICollection<CommentDto> Comments { get; set; }
    public ICollection<VideoAndCategoryDto> VideoAndCategories { get; set; }
}