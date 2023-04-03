using VideoManagementApi.Domain.Entities;

namespace VideoManagementApi.Application.Features.AdvertisementFeatures.Queries;

public class GetAllAdvertisementsQuery : IRequest<IResult<List<Advertisement>>>
{
}