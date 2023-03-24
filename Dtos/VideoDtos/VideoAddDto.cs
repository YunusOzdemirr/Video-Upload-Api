using VideoManagementApi.Dtos.SeoDtos;
using VideoManagementApi.Models;

namespace VideoManagementApi.Dtos.VideoDtos;

public class VideoAddDto
{
    public string Title { get; set; }
    public string Description { get; set; }
    public IFormFile File { get; set; }
    public ICollection<SeoAddDto> Seos { get; set; }
    public ICollection<Category> VideoAndCategories { get; set; }
}