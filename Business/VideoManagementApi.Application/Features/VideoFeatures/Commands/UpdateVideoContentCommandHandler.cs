using VideoManagementApi.Application.Interfaces.Services;

namespace VideoManagementApi.Application.Features.VideoFeatures.Commands;

public class UpdateVideoContentCommandHandler : IRequestHandler<UpdateVideoContentCommand, IResult<int>>
{
    private readonly IVideoService _videoService;

    public UpdateVideoContentCommandHandler(IVideoService videoService)
    {
        _videoService = videoService;
    }

    public async Task<IResult<int>> Handle(UpdateVideoContentCommand request, CancellationToken cancellationToken)
    {
        return await _videoService.UpdateUploadAsync(request,cancellationToken);
    }
}