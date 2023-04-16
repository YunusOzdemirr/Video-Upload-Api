using Microsoft.AspNetCore.Http;

namespace VideoManagementApi.Application.Features.AdvertisementFeatures.Commands;

public class UpdateAdvertisementContentCommand : IRequest<IResult<int>>
{
    public int Id { get; set; }
    public IFormFile File { get; set; }
}