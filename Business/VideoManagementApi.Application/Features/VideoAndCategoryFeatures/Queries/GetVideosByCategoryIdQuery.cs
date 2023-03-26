using VideoManagementApi.Domain.Entities;

namespace VideoManagementApi.Application.Features.VideoAndCategoryFeatures.Queries;

public class GetVideosByCategoryIdQuery : IRequest<IResult<List<VideoAndCategory>>>
{
    public int CategoryId { get; set; }
}