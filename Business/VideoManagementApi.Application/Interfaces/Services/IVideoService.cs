using VideoManagementApi.Application.Features.VideoFeatures.Commands;
using VideoManagementApi.Application.Features.VideoFeatures.Queries;
using VideoManagementApi.Domain.Entities;

namespace VideoManagementApi.Application.Interfaces.Services;

public interface IVideoService
{
    Task<IResult> UploadAsync(CreateVideoCommand createVideoCommand, CancellationToken cancellationToken);
    Task<IResult> UpdateAsync(UpdateVideoCommand updateVideoCommand, CancellationToken cancellationToken);
    Task<IResult<List<Video>>> GetVideos(GetVideosQuery query, CancellationToken cancellationToken);
}