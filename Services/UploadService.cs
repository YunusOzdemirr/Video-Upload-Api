using AutoMapper;
using Microsoft.EntityFrameworkCore;
using VideoManagementApi.DataAccess.EntityFramework;
using VideoManagementApi.Dtos.VideoDtos;
using VideoManagementApi.Models;
using VideoManagementApi.Services.Abstract;
using VideoManagementApi.Utilities;

namespace VideoManagementApi.Services;

public class UploadService : IUploadService
{
    private VideoContext _videoContext;
    private IMapper _mapper;

    public UploadService(VideoContext videoContext, IMapper mapper)
    {
        _videoContext = videoContext;
        _mapper = mapper;
    }

    public async Task<Utilities.IResult> UploadAsync(VideoAddDto videoAddDto)
    {
        var result = await FileUpload.Update(videoAddDto.File, "Videos", "");
        if (!result.Succeeded)
            return result;
        var video = new Video()
        {
            FileName = videoAddDto.File.Name,
            FilePath = result.Data as string,
            Description = videoAddDto.Description,
            Title = videoAddDto.Title,
            WatchCount = 0,
            CreatedDate = DateTime.Now
        };
        await _videoContext.Videos.AddAsync(video);
        return await Result.SuccessAsync();
    }

    public async Task<IResult<List<VideoDto>>> GetVideos()
    {
        var videos = await _videoContext.Videos.AsNoTracking().ToListAsync();
        var videoDtos = _mapper.Map<List<VideoDto>>(videos);
        return await Result<List<VideoDto>>.SuccessAsync(videoDtos);
    }
}