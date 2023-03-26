using VideoManagementApi.Application.Interfaces.Services;

namespace VideoManagementApi.Application.Features.LikeFeatures.Commands;

public class CreateOrUpdateLikeCommandHandler : IRequestHandler<CreateOrUpdateLikeCommand, IResult>
{
    private readonly ILikeService _likeService;

    public CreateOrUpdateLikeCommandHandler(ILikeService likeService)
    {
        _likeService = likeService;
    }

    public async Task<IResult> Handle(CreateOrUpdateLikeCommand request, CancellationToken cancellationToken)
    {
        return await _likeService.CreateOrUpdateAsync(request, cancellationToken);
    }
}