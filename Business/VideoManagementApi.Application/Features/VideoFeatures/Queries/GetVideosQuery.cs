using VideoManagementApi.Domain.Entities;

namespace VideoManagementApi.Application.Features.VideoFeatures.Queries;

public class GetVideosQuery : IRequest<IResult<List<Video>>>
{
    public bool? IsActive { get; set; }
}