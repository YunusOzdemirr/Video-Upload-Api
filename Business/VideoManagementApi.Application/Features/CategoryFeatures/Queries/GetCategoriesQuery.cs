using VideoManagementApi.Domain.Entities;

namespace VideoManagementApi.Application.Features.CategoryFeatures.Queries;

public class GetCategoriesQuery : IRequest<IResult<List<Category>>>
{
    public bool IsActive { get; set; }
}