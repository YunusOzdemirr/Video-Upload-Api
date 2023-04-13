namespace VideoManagementApi.API.ViewModels.Requests;

public class UpdateSeoRequest
{
    public int Id { get; set; }
    public string Tag { get; set; }
    public string Description { get; set; }
    public int VideoId { get; set; }
}