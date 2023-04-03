using VideoManagementApi.Domain.Entities;

namespace VideoManagementApi.Application.Features.AdvertisementFeatures.Queries;

public class GetAdvertisementQueryHandler : IRequestHandler<GetAdvertisementQuery, IResult<Advertisement>>
{
    private IAdvertisementRepository _advertisementRepository;

    public GetAdvertisementQueryHandler(IAdvertisementRepository advertisementRepository)
    {
        _advertisementRepository = advertisementRepository;
    }

    public async Task<IResult<Advertisement>> Handle(GetAdvertisementQuery request, CancellationToken cancellationToken)
    {
        var result= await _advertisementRepository.GetByIdAsync(request.Id, cancellationToken);
        return await Result<Advertisement>.SuccessAsync(result);
    }
}