using VideoManagementApi.Application.Interfaces.Services;

namespace VideoManagementApi.Application.Features.CategoryFeatures.Commands;

public class AddCountCategoryCommandHandler : IRequestHandler<AddCountCategoryCommand, IResult>
{
    private readonly ICategoryService _categoryService;

    public AddCountCategoryCommandHandler(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    public async Task<IResult> Handle(AddCountCategoryCommand request, CancellationToken cancellationToken)
    {
        return await _categoryService.AddCountAsync(request, cancellationToken);
    }
}