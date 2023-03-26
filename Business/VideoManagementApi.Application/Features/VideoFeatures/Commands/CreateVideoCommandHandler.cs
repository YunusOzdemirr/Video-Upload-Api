using VideoManagementApi.Application.Interfaces.Services;

namespace VideoManagementApi.Application.Features.VideoFeatures.Commands;

public class CreateVideoCommandHandler : IRequestHandler<CreateVideoCommand, IResult>
{
    private IUploadService _uploadService;

    public CreateVideoCommandHandler(IUploadService uploadService)
    {
        _uploadService = uploadService;
    }

    public async Task<IResult> Handle(CreateVideoCommand request, CancellationToken cancellationToken)
    {
        return await _uploadService.UploadAsync(request, cancellationToken);
    }
}