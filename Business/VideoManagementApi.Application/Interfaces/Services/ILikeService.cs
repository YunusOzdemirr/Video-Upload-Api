using VideoManagementApi.Application.Features.LikeFeatures.Commands;
using VideoManagementApi.Application.Features.LikeFeatures.Queries;
using VideoManagementApi.Domain.Entities;

namespace VideoManagementApi.Application.Interfaces.Services;

public interface ILikeService
{
    Task<IResult> CreateOrUpdateAsync(CreateOrUpdateLikeCommand createLikeCommand, CancellationToken cancellationToken);
    Task<IResult<List<Like>>> GetAllAsync(GetLikesQuery getLikesQuery, CancellationToken cancellationToken);
}