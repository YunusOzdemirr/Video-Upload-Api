namespace VideoManagementApi.Application.Features.AdvertisementFeatures.Commands;

public class DeleteAdvertisementCommandHandler : IRequestHandler<DeleteAdvertisementCommand, IResult>
{
    private readonly IAdvertisementRepository _repository;

    public DeleteAdvertisementCommandHandler(IAdvertisementRepository repository)
    {
        _repository = repository;
    }

    public async Task<IResult> Handle(DeleteAdvertisementCommand request, CancellationToken cancellationToken)
    {
        var result= await _repository.DeleteByIdAsync(request.Id,cancellationToken);
        if (result)
            return await Result.SuccessAsync();
        return await Result.FailAsync();
    }
}