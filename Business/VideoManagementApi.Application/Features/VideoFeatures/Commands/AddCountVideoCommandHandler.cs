using VideoManagementApi.Application.Interfaces.Services;

namespace VideoManagementApi.Application.Features.VideoFeatures.Commands;

public class AddCountVideoCommandHandler : IRequestHandler<AddCountVideoCommand, IResult>
{
    private readonly IVideoService _videoService;

    public AddCountVideoCommandHandler(IVideoService videoService)
    {
        _videoService = videoService;
    }

    public async Task<IResult> Handle(AddCountVideoCommand request, CancellationToken cancellationToken)
    {
        return await _videoService.AddCountAsync(request, cancellationToken);
    }
}