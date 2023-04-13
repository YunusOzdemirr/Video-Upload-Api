namespace VideoManagementApi.API.ViewModels.Requests;

public class CreateCommentRequest
{
    public string Name { get; set; }
    public string Content { get; set; }
    public int VideoId { get; set; }
}