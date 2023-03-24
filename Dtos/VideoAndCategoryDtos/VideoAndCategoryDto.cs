using VideoManagementApi.Dtos.CategoryDtos;
using VideoManagementApi.Dtos.VideoDtos;

namespace VideoManagementApi.Dtos.VideoAndCategoryDtos;

public class VideoAndCategoryDto
{
    public int VideoId { get; set; }
    public VideoDto Video { get; set; }
    public int CategoryId { get; set; }
    public CategoryDto Category { get; set; }
}