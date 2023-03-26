using VideoManagementApi.Application.Interfaces.Services;

namespace VideoManagementApi.Application.Features.CategoryFeatures.Commands;

public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, IResult>
{
    private readonly ICategoryService _categoryService;

    public CreateCategoryCommandHandler(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    public async Task<IResult> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        return await _categoryService.CreateAsync(request, cancellationToken);
    }
}