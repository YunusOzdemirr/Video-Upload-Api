namespace VideoManagementApi.Application.Features.CategoryFeatures.Commands;

public class ChangeStatusCategoryCommandHandler : IRequestHandler<ChangeStatusCategoryCommand, IResult>
{
    private readonly ICategoryRepository _repository;

    public ChangeStatusCategoryCommandHandler(ICategoryRepository repository)
    {
        _repository = repository;
    }

    public async Task<IResult> Handle(ChangeStatusCategoryCommand request, CancellationToken cancellationToken)
    {
        var result = await _repository.ChangeStatusAsync(request.Id, request.IsActive, cancellationToken);
        if (result)
            return await Result.SuccessAsync();
        return await Result.FailAsync();
    }
}