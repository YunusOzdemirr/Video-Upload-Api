using VideoManagementApi.Application.Interfaces.Services;

namespace VideoManagementApi.Application.Features.AdvertisementFeatures.Commands;

public class UpdateAdvertisementCommandHandler : IRequestHandler<UpdateAdvertisementCommand, IResult>
{
    private readonly IAdvertisementService _advertisementService;

    public UpdateAdvertisementCommandHandler(IAdvertisementService advertisementService)
    {
        _advertisementService = advertisementService;
    }

    public async Task<IResult> Handle(UpdateAdvertisementCommand request, CancellationToken cancellationToken)
    {
        return await _advertisementService.UpdateAsync(request, cancellationToken);
    }
}