using VideoManagementApi.Application.Interfaces.Services;

namespace VideoManagementApi.Application.Features.AdvertisementFeatures.Commands;

public class AddCountAdvertisementCommandHandler : IRequestHandler<AddCountAdvertisementCommand, IResult>
{
    private readonly IAdvertisementService _advertisementService;

    public AddCountAdvertisementCommandHandler(IAdvertisementService advertisementService)
    {
        _advertisementService = advertisementService;
    }

    public async Task<IResult> Handle(AddCountAdvertisementCommand request, CancellationToken cancellationToken)
    {
        var result = await _advertisementService.AddCountAsync(request, cancellationToken);
        if (result.Succeeded)
            return await Result.SuccessAsync();
        return await Result.FailAsync();
    }
}