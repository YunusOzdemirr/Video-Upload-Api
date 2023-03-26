namespace VideoManagementApi.Application.Features.AdvertisementFeatures.Commands;

public class UpdateAdvertisementCommand : IRequest<IResult>
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string FilePath { get; set; }
    public string FileName { get; set; }
    public string Url { get; set; }
    public int WatchCount { get; set; }
    public int ClickCount { get; set; }
    public int Rank { get; set; }
}