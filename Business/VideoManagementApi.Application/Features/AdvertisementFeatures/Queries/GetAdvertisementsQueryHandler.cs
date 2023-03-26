using VideoManagementApi.Application.Interfaces.Services;
using VideoManagementApi.Domain.Entities;

namespace VideoManagementApi.Application.Features.AdvertisementFeatures.Queries;

public class GetAdvertisementsQueryHandler : IRequestHandler<GetAdvertisementsQuery, IResult<List<Advertisement>>>
{
    private readonly IAdvertisementService _advertisementService;

    public GetAdvertisementsQueryHandler(IAdvertisementService advertisementService)
    {
        _advertisementService = advertisementService;
    }

    public async Task<IResult<List<Advertisement>>> Handle(GetAdvertisementsQuery request,
        CancellationToken cancellationToken)
    {
        return await _advertisementService.GetAllAsync(request, cancellationToken);
    }
}