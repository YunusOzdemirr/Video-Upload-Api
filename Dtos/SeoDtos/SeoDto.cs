using VideoManagementApi.Dtos.VideoDtos;

namespace VideoManagementApi.Dtos.SeoDtos;

public class SeoDto
{
    public int Id { get; set; }
    public string Tag { get; set; }
    public string Description { get; set; }
    public int VideoId { get; set; }
    public VideoDto Video { get; set; }
}