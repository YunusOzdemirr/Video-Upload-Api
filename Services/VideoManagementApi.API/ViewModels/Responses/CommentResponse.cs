namespace VideoManagementApi.API.ViewModels.Responses;

public class CommentResponse
{
    public string IpAddress { get; set; }
    public string Name { get; set; }
    public string Content { get; set; }
    public bool IsApproved { get; set; }
    public int VideoId { get; set; }
}