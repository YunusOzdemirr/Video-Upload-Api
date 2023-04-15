using VideoManagementApi.Application.Features.CategoryFeatures.Commands;
using VideoManagementApi.Application.Features.CategoryFeatures.Queries;
using VideoManagementApi.Domain.Entities;

namespace VideoManagementApi.Application.Interfaces.Services;

public interface ICategoryService
{
    Task<IResult> CreateAsync(CreateCategoryCommand createCategoryCommand, CancellationToken cancellationToken);

    Task<IResult<List<Category>>> GetAllAsync(GetCategoriesQuery getCategoriesQuery,
        CancellationToken cancellationToken);

    Task<IResult> UpdateAsync(UpdateCategoryCommand updateCategoryCommand,
        CancellationToken cancellationToken);
}