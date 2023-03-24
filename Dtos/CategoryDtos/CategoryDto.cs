using VideoManagementApi.Dtos.VideoAndCategoryDtos;

namespace VideoManagementApi.Dtos.CategoryDtos;

public abstract class CategoryDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string FilePath { get; set; }
    public string FileName { get; set; }
    public ICollection<VideoAndCategoryDto> VideoAndCategories { get; set; }
}