namespace VideoManagementApi.API.ViewModels.Requests;

public class CreateOrUpdateLikeRequest
{
    public int VideoId { get; set; }
    public bool IsLiked { get; set; }
}