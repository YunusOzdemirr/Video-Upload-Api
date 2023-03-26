using VideoManagementApi.Application.Interfaces.Services;

namespace VideoManagementApi.Application.Features.VideoFeatures.Commands;

public class UpdateVideoCommandHandler : IRequestHandler<UpdateVideoCommand, IResult>
{
    private readonly IUploadService _uploadService;

    public UpdateVideoCommandHandler(IUploadService uploadService)
    {
        _uploadService = uploadService;
    }

    public async Task<IResult> Handle(UpdateVideoCommand request, CancellationToken cancellationToken)
    {
        return await _uploadService.UpdateAsync(request, cancellationToken);
    }
}