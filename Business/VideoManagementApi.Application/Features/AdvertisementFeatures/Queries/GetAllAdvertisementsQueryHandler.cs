using VideoManagementApi.Application.Interfaces.Services;
using VideoManagementApi.Domain.Entities;

namespace VideoManagementApi.Application.Features.AdvertisementFeatures.Queries;

public class GetAllAdvertisementsQueryHandler : IRequestHandler<GetAllAdvertisementsQuery, IResult<List<Advertisement>>>
{
    private readonly IAdvertisementService _advertisementService;

    public GetAllAdvertisementsQueryHandler(IAdvertisementService advertisementService)
    {
        _advertisementService = advertisementService;
    }

    public async Task<IResult<List<Advertisement>>> Handle(GetAllAdvertisementsQuery request,
        CancellationToken cancellationToken)
    {
        return await _advertisementService.GetAllAsync(request, cancellationToken);
    }
}