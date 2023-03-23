namespace VideoManagementApi.Dtos.VideoDtos;

public class VideoAddDto
{
    public string Title { get; set; }
    public string Description { get; set; }
    public IFormFile File { get; set; }
}