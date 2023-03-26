using VideoManagementApi.Domain.Entities;

namespace VideoManagementApi.Application.Features.VideoAndCategoryFeatures.Queries;

public class GetCategoriesByVideoIdQuery : IRequest<IResult<List<VideoAndCategory>>>
{
    public int VideoId { get; set; }
}