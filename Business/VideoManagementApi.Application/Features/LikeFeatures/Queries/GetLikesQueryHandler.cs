using VideoManagementApi.Application.Interfaces.Services;
using VideoManagementApi.Domain.Entities;

namespace VideoManagementApi.Application.Features.LikeFeatures.Queries;

public class GetLikesQueryHandler : IRequestHandler<GetLikesQuery, IResult<List<Like>>>
{
    private readonly ILikeService _likeService;

    public GetLikesQueryHandler(ILikeService likeService)
    {
        _likeService = likeService;
    }

    public async Task<IResult<List<Like>>> Handle(GetLikesQuery request, CancellationToken cancellationToken)
    {
        return await _likeService.GetAllAsync(request, cancellationToken);
    }
}