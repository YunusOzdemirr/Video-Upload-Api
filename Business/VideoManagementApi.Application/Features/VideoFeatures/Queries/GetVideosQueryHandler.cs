using VideoManagementApi.Application.Interfaces.Services;
using VideoManagementApi.Domain.Entities;

namespace VideoManagementApi.Application.Features.VideoFeatures.Queries;

public class GetVideosQueryHandler : IRequestHandler<GetVideosQuery, IResult<List<Video>>>
{
    private readonly IVideoService _uploadService;

    public GetVideosQueryHandler(IVideoService uploadService)
    {
        _uploadService = uploadService;
    }

    public async Task<IResult<List<Video>>> Handle(GetVideosQuery request, CancellationToken cancellationToken)
    {
        var result = await _uploadService.GetVideos(request, cancellationToken);
        return result;
    }
}