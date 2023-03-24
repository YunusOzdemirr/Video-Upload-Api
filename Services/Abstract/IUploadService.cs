using VideoManagementApi.Dtos.VideoDtos;
using VideoManagementApi.Utilities;
using IResult = VideoManagementApi.Utilities.IResult;

namespace VideoManagementApi.Services.Abstract;

public interface IUploadService
{
    Task<IResult> UploadAsync(VideoAddDto videoAddDto);
    Task<IResult> UpdateAsync(VideoUpdateDto videoUpdateDto);
    Task<IResult<List<VideoDto>>> GetVideos();
}
