using VideoManagementApi.Application.Interfaces.Services;

namespace VideoManagementApi.Application.Features.AdvertisementFeatures.Commands;

public class UpdateAdvertisementContentCommandHandler : IRequestHandler<UpdateAdvertisementContentCommand, IResult<int>>
{
    private readonly IAdvertisementService _advertisementService;

    public UpdateAdvertisementContentCommandHandler(IAdvertisementService advertisementService)
    {
        _advertisementService = advertisementService;
    }

    public async Task<IResult<int>> Handle(UpdateAdvertisementContentCommand request, CancellationToken cancellationToken)
    {
        return await _advertisementService.UpdateUploadAsync(request, cancellationToken);
    }
}