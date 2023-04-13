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

    public async Task<IResult<int>> UploadAsync(CreateVideoCommand createVideoCommand,
        CancellationToken cancellationToken)
    {
        var result = await FileUpload.UploadAlternative(createVideoCommand.File, "Videos", "");
        if (!result.Succeeded)
            return await Result<int>.FailAsync();
        var video = new Video()
        {
            FileName = result.Message,
            FilePath = result.Data as string,
            Description = createVideoCommand.Description,
            Title = createVideoCommand.Title,
            WatchCount = 0,
        };
        await _videoRepository.AddAsync(video, cancellationToken);
        return await Result<int>.SuccessAsync(video.Id);
    }

    public async Task<IResult<int>> UpdateUploadAsync(UpdateVideoContentCommand updateVideoContentCommand,
        CancellationToken cancellationToken)
    {
        var video = await _videoRepository.GetByIdAsync(updateVideoContentCommand.Id, cancellationToken);
        if (video == null)
        {
            var videoCommand = new CreateVideoCommand()
            {
                Title = "Video Bilgileri Bekleniyor.",
                Description = "Upload Başarılı 2. Adım Bekleniyor || Update işlemi içerisinde create edilen video",
                File = updateVideoContentCommand.File
            };
            var videoId = await UploadAsync(videoCommand, cancellationToken);
            if (videoId.Succeeded)
                return await Result<int>.SuccessAsync(data: videoId.Data as int? ?? default(int));
            return await Result<int>.FailAsync(default(int));
        }

        var result = await FileUpload.UploadAlternative(updateVideoContentCommand.File, "Videos", "");
        if (!result.Succeeded)
            return await Result<int>.FailAsync();
        await FileUpload.Delete(video.FilePath);
        video.FileName = result.Message;
        video.FilePath = result.Data as string;
        await _videoRepository.UpdateAsync(video, cancellationToken);
        return await Result<int>.SuccessAsync(video.Id);
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