namespace VideoManagementApi.Application.Features.CategoryFeatures.Commands;

public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, IResult>
{
    private readonly ICategoryRepository _categoryRepository;

    public DeleteCategoryCommandHandler(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public async Task<IResult> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
    {
        var result = await _categoryRepository.HardDeleteByIdAsync(request.Id, cancellationToken);
        if (result)
            return await Result.SuccessAsync();
        return await Result.FailAsync();
    }
}