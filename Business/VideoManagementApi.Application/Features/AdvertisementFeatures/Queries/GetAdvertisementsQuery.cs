using VideoManagementApi.Domain.Entities;

namespace VideoManagementApi.Application.Features.AdvertisementFeatures.Queries;

public class GetAdvertisementsQuery : IRequest<IResult<List<Advertisement>>>
{
}