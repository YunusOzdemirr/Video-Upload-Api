using VideoManagementApi.Domain.Entities;

namespace VideoManagementApi.Application.Features.VideoFeatures.Queries;

public class GetVideoQueryHandler : IRequestHandler<GetVideoQuery, IResult<Video>>
{
    private readonly IVideoRepository _videoRepository;

    public GetVideoQueryHandler(IVideoRepository videoRepository)
    {
        _videoRepository = videoRepository;
    }

    public async Task<IResult<Video>> Handle(GetVideoQuery request, CancellationToken cancellationToken)
    {
        var video = await _videoRepository.GetByIdAsync(request.Id,cancellationToken);
        return await Result<Video>.SuccessAsync(video);
    }
}