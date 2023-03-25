using VideoManagementApi.Dtos.VideoDtos;
using VideoManagementApi.Features.Commands.VideoCommands;
using VideoManagementApi.Features.Queries.VideoQueries;
using VideoManagementApi.Models;
using VideoManagementApi.Utilities;
using IResult = VideoManagementApi.Utilities.IResult;

namespace VideoManagementApi.Services.Abstract;

public interface IUploadService
{
    Task<IResult> UploadAsync(CreateVideoCommand createVideoCommand);
    Task<IResult> UpdateAsync(UpdateVideoCommand updateVideoCommand);
    Task<IResult<List<Video>>> GetVideos(GetVideosQuery query);
}
