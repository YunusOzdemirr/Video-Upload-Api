using AutoMapper;
using Microsoft.EntityFrameworkCore;
using VideoManagementApi.DataAccess.EntityFramework;
using VideoManagementApi.DataAccess.Repositories.Abstract;
using VideoManagementApi.Dtos.VideoDtos;
using VideoManagementApi.Features.Commands.VideoCommands;
using VideoManagementApi.Features.Queries.VideoQueries;
using VideoManagementApi.Models;
using VideoManagementApi.Services.Abstract;
using VideoManagementApi.Utilities;
using IResult = VideoManagementApi.Utilities.IResult;

namespace VideoManagementApi.Services;

public class UploadService : IUploadService
{
    private VideoContext _videoContext;
    private IVideoRepository _videoRepository;
    private IMapper _mapper;

    public UploadService(VideoContext videoContext, IMapper mapper, IVideoRepository videoRepository)
    {
        _videoContext = videoContext;
        _mapper = mapper;
        _videoRepository = videoRepository;
    }

    public async Task<IResult> UploadAsync(CreateVideoCommand createVideoCommand)
    {
        var result = await FileUpload.Update(createVideoCommand.File, "Videos", "");
        if (!result.Succeeded)
            return result;
        var video = new Video()
        {
            FileName = createVideoCommand.File.Name,
            FilePath = result.Data as string,
            Description = createVideoCommand.Description,
            Title = createVideoCommand.Title,
            WatchCount = 0,
            CreatedDate = DateTime.Now
        };
        await _videoRepository.AddAsync(video);
        return await Result.SuccessAsync();
    }

    public async Task<IResult> UpdateAsync(UpdateVideoCommand videoUpdateDto)
    {
        var video = await _videoContext.Videos.SingleOrDefaultAsync(a => a.Id == videoUpdateDto.Id);
        if (video == null)
            return await Result.FailAsync();
        var newVideo = _mapper.Map<UpdateVideoCommand, Video>(videoUpdateDto, video);
        await _videoRepository.UpdateAsync(newVideo);
        return await Result.SuccessAsync();
    }

    public async Task<IResult<List<Video>>> GetVideos(GetVideosQuery query)
    {
        var videos = query.IsActive == null
            ? await _videoRepository.GetAllAsync()
            : await _videoRepository.GetAllAsync(a => a.IsActive == query.IsActive);
        return await Result<List<Video>>.SuccessAsync(videos);
    }
}