using VideoManagementApi.Application.Features.SeoFeatures.Commands;
using VideoManagementApi.Application.Features.VideoAndCategoryFeatures.Commands;
using VideoManagementApi.Application.Features.VideoFeatures.Commands;
using VideoManagementApi.Application.Features.VideoFeatures.Queries;
using VideoManagementApi.Domain.Entities;

namespace VideoManagementApi.Application.Interfaces.Services;

public interface IVideoService
{
    Task<IResult<int>> UploadAsync(CreateVideoCommand createVideoCommand, CancellationToken cancellationToken);
    Task<IResult> UpdateAsync(UpdateVideoCommand updateVideoCommand, CancellationToken cancellationToken);
    Task<IResult<int>> UpdateUploadAsync(UpdateVideoContentCommand updateVideoContentCommand,
        CancellationToken cancellationToken);
    Task<IResult<List<Video>>> GetVideos(GetVideosQuery query, CancellationToken cancellationToken);
    Task<IResult> AddCountAsync(AddCountVideoCommand command, CancellationToken cancellationToken);
}