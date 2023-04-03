using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using VideoManagementApi.Application.Features.SeoFeatures.Commands;
using VideoManagementApi.Application.Features.VideoAndCategoryFeatures.Commands;
using VideoManagementApi.Application.Features.VideoFeatures.Commands;
using VideoManagementApi.Application.Features.VideoFeatures.Queries;
using VideoManagementApi.Application.Interfaces.Services;
using VideoManagementApi.Domain.Common;
using VideoManagementApi.Domain.Entities;
using VideoManagementApi.Infrastructure.Context;
using VideoManagementApi.Infrastructure.Utilities;

namespace VideoManagementApi.Infrastructure.Services;

public class VideoService : IVideoService
{
    private readonly VideoContext _videoContext;
    private readonly IVideoRepository _videoRepository;
    private readonly IMapper _mapper;

    public VideoService(VideoContext videoContext, IMapper mapper, IVideoRepository videoRepository)
    {
        _videoContext = videoContext;
        _mapper = mapper;
        _videoRepository = videoRepository;
    }

    public async Task<IResult> UploadAsync(CreateVideoCommand createVideoCommand, CancellationToken cancellationToken)
    {
        var result = await FileUpload.UploadAlternative(createVideoCommand.File, "Videos", "");
        if (!result.Succeeded)
            return result;
        var video = new Video()
        {
            FileName = result.Message,
            FilePath = result.Data as string,
            Description = createVideoCommand.Description,
            Title = createVideoCommand.Title,
            WatchCount = 0,
        };
        await _videoRepository.AddAsync(video, cancellationToken);
        await CreateVideoAndCategoriesAsync(createVideoCommand.VideoAndCategories, createVideoCommand.Seos, video.Id,
            cancellationToken);
        return await Result.SuccessAsync();
    }

    public async Task<IResult> UpdateAsync(UpdateVideoCommand updateVideoCommand, CancellationToken cancellationToken)
    {
        var video = await _videoContext.Videos.SingleOrDefaultAsync(a => a.Id == updateVideoCommand.Id,
            cancellationToken);
        if (video == null)
            return await Result.FailAsync();
        var newVideo = _mapper.Map<UpdateVideoCommand, Video>(updateVideoCommand, video);
        await _videoRepository.UpdateAsync(newVideo, cancellationToken);
        await CreateVideoAndCategoriesAsync(updateVideoCommand.VideoAndCategories, updateVideoCommand.Seos, video.Id,
            cancellationToken);
        return await Result.SuccessAsync();
    }

    public async Task<IResult<List<Video>>> GetVideos(GetVideosQuery query, CancellationToken cancellationToken)
    {
        var videos = query.IsActive == null
            ? await _videoContext.Videos
                .Include(a => a.Comments.Where(a => a.IsApproved))
                .Include(a => a.Likes)
                .Include(a => a.Seos)
                .Include(a => a.VideoAndCategories)
                .ToListAsync(cancellationToken)
            : await _videoContext.Videos
                .Include(a => a.Comments.Where(a => a.IsApproved))
                .Include(a => a.Likes)
                .Include(a => a.Seos)
                .Include(a => a.VideoAndCategories)
                .Where(a => a.IsActive).ToListAsync(cancellationToken);
        return await Result<List<Video>>.SuccessAsync(videos);
    }

    private async Task<bool> CreateVideoAndCategoriesAsync(List<CreateVideoAndCategoryCommand> videoAndCategories,
        List<CreateSeoCommand> seos, int videoId, CancellationToken cancellationToken)
    {
        if (videoAndCategories != null && videoAndCategories.Count > 0)
            foreach (var videoAndCategoryCommand in videoAndCategories)
            {
                videoAndCategoryCommand.VideoId = videoId;
                var videoAndCategory = _mapper.Map<VideoAndCategory>(videoAndCategoryCommand);
                await _videoContext.VideoAndCategories.AddAsync(videoAndCategory, cancellationToken);
            }

        if (seos != null && seos.Count > 0)
            foreach (var seoCommand in seos)
            {
                seoCommand.VideoId = videoId;
                var seo = _mapper.Map<Seo>(seoCommand);
                await _videoContext.Seos.AddAsync(seo, cancellationToken);
            }

        return await _videoContext.SaveChangesAsync(cancellationToken) > 1;
    }
}