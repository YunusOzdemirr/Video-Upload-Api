namespace VideoManagementApi.API.ViewModels.Requests;

public class CreateCategoryRequest
{
    public string Name { get; set; }
    public IFormFile File { get; set; }
}