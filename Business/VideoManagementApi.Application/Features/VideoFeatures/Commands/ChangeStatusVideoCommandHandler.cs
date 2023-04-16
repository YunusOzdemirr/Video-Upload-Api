namespace VideoManagementApi.Application.Features.VideoFeatures.Commands;

public class ChangeStatusVideoCommandHandler : IRequestHandler<ChangeStatusVideoCommand, IResult>
{
    private readonly IVideoRepository _videoRepository;

    public ChangeStatusVideoCommandHandler(IVideoRepository videoRepository)
    {
        _videoRepository = videoRepository;
    }

    public async Task<IResult> Handle(ChangeStatusVideoCommand request, CancellationToken cancellationToken)
    {
        var result = await _videoRepository.ChangeStatusAsync(request.Id, request.IsActive, cancellationToken);
        if (result)
            return await Result.SuccessAsync();
        return await Result.FailAsync();
    }
}