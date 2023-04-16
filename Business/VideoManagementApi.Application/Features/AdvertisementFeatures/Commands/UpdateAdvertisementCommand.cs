using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;

namespace VideoManagementApi.Application.Features.AdvertisementFeatures.Commands;

public class UpdateAdvertisementCommand : IRequest<IResult>
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public IFormFile File { get; set; }
    public string Url { get; set; }
    public string Orginator { get; set; }
    public string OrginatorPhone { get; set; }
    public int WatchCount { get; set; }
    public int ClickCount { get; set; }
    public int Rank { get; set; }
}