namespace VideoManagementApi.API.ViewModels.Responses;

public class LikesResponse
{
    public int Id { get; set; }
    public string IpAddress { get; set; }
    public bool IsLiked { get; set; }
    public int VideoId { get; set; }
}