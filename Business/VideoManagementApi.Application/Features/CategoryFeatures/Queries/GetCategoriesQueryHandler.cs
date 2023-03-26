using VideoManagementApi.Application.Interfaces.Services;
using VideoManagementApi.Domain.Entities;

namespace VideoManagementApi.Application.Features.CategoryFeatures.Queries;

public class GetCategoriesQueryHandler : IRequestHandler<GetCategoriesQuery, IResult<List<Category>>>
{
    private readonly ICategoryService _categoryService;

    public GetCategoriesQueryHandler(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    public async Task<IResult<List<Category>>> Handle(GetCategoriesQuery request, CancellationToken cancellationToken)
    {
        return await _categoryService.GetAllAsync(request, cancellationToken);
    }
}