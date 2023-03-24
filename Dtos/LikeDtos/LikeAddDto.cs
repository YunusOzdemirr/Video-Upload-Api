namespace VideoManagementApi.Dtos.LikeDtos;

public class LikeAddDto
{
    public string IpAddress { get; set; }
    public bool IsLiked { get; set; }
    public int VideoId { get; set; }
}