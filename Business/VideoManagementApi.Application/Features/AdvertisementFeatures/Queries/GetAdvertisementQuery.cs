using VideoManagementApi.Application.Interfaces.Services;
using VideoManagementApi.Domain.Entities;

namespace VideoManagementApi.Application.Features.AdvertisementFeatures.Queries;

public class GetAdvertisementQuery : IRequest<IResult<Advertisement>>
{
    public int Id { get; set; }
}