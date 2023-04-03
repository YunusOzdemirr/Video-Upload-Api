using VideoManagementApi.Domain.Entities;

namespace VideoManagementApi.Application.Features.VideoFeatures.Queries;

public class GetVideoQuery : IRequest<IResult<Video>>
{
    public int Id { get; set; }
}