namespace VideoManagementApi.Application.Features.AdvertisementFeatures.Commands;

public class ChangeStatusAdvertisementCommandHandler : IRequestHandler<ChangeStatusAdvertisementCommand, IResult>
{
    private readonly IAdvertisementRepository _repository;

    public ChangeStatusAdvertisementCommandHandler(IAdvertisementRepository repository)
    {
        _repository = repository;
    }

    public async Task<IResult> Handle(ChangeStatusAdvertisementCommand request, CancellationToken cancellationToken)
    {
        var result = await _repository.ChangeStatusAsync(request.Id, request.IsActive, cancellationToken);
        if (result)
            return await Result.SuccessAsync();
        return await Result.FailAsync();
    }
}