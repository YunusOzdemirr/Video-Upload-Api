namespace VideoManagementApi.API.ViewModels.Requests;

public class UpdateAdvertisementRequest
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Url { get; set; }
    public string Orginator { get; set; }
    public string OrginatorPhone { get; set; }
    public int Rank { get; set; }
}