namespace VideoManagementApi.API.ViewModels.Requests;

public class CreateSeoRequest
{
    public string Tag { get; set; }
    public string Description { get; set; }
    public int VideoId { get; set; }
}