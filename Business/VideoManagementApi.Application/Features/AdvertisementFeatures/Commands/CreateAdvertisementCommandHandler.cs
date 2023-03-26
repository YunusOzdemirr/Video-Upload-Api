using VideoManagementApi.Application.Interfaces.Services;

namespace VideoManagementApi.Application.Features.AdvertisementFeatures.Commands;

public class CreateAdvertisementCommandHandler : IRequestHandler<CreateAdvertisementCommand, IResult>
{
    private readonly IAdvertisementService _advertisementService;

    public CreateAdvertisementCommandHandler(IAdvertisementService advertisementService)
    {
        _advertisementService = advertisementService;
    }

    public async Task<IResult> Handle(CreateAdvertisementCommand request, CancellationToken cancellationToken)
    {
        return await _advertisementService.CreateAsync(request, cancellationToken);
    }
}