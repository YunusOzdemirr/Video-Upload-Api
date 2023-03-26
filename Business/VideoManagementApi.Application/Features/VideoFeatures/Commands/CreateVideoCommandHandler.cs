using VideoManagementApi.Application.Interfaces.Services;

namespace VideoManagementApi.Application.Features.VideoFeatures.Commands;

public class CreateVideoCommandHandler : IRequestHandler<CreateVideoCommand, IResult>
{
    private IVideoService _uploadService;

    public CreateVideoCommandHandler(IVideoService uploadService)
    {
        _uploadService = uploadService;
    }

    public async Task<IResult> Handle(CreateVideoCommand request, CancellationToken cancellationToken)
    {
        return await _uploadService.UploadAsync(request, cancellationToken);
    }
}