using VideoManagementApi.Models;

namespace VideoManagementApi.Dtos.LikeDtos;

public class LikeDto
{
    public int Id { get; set; }
    public string IpAddress { get; set; }
    public bool IsLiked { get; set; }
    public int VideoId { get; set; }
    public Video Video { get; set; }
}