using VideoManagementApi.Dtos.VideoAndCategoryDtos;

namespace VideoManagementApi.Dtos.CategoryDtos;

public  class CategoryAddDto
{
    public string Name { get; set; }
    public IFormFile File { get; set; }
}

public abstract class CategoryDto
{
    public string Name { get; set; }
    public string FilePath { get; set; }
    public string FileName { get; set; }
    public ICollection<VideoAndCategoryDto> VideoAndCategories { get; set; }
}