namespace VideoManagementApi.Dtos.CategoryDtos;

public class CategoryUpdateDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public IFormFile File { get; set; }
}