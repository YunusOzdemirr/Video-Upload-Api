using VideoManagementApi.Domain.Entities;

namespace VideoManagementApi.Application.Features.LikeFeatures.Queries;

public class GetLikesQuery : IRequest<IResult<List<Like>>>
{
    public int VideoId { get; set; }
}