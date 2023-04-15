using VideoManagementApi.Application.Interfaces.Services;

namespace VideoManagementApi.Application.Features.CategoryFeatures.Commands;

public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, IResult>
{
    private readonly ICategoryService _categoryService;

    public UpdateCategoryCommandHandler(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    public async Task<IResult> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
    {
        var result = await _categoryService.UpdateAsync(request, cancellationToken);
        if (result.Succeeded)
            return await Result.SuccessAsync();
        return await Result.FailAsync();
    }
}