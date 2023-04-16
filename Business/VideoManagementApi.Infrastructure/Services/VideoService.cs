using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using VideoManagementApi.Application.Features.AdvertisementFeatures.Commands;
using VideoManagementApi.Application.Features.SeoFeatures.Commands;
using VideoManagementApi.Application.Features.VideoAndCategoryFeatures.Commands;
using VideoManagementApi.Application.Features.VideoFeatures.Commands;
using VideoManagementApi.Application.Features.VideoFeatures.Queries;
using VideoManagementApi.Application.Interfaces.Services;
using VideoManagementApi.Domain.Common;
using VideoManagementApi.Domain.Entities;
using VideoManagementApi.Domain.Enums;
using VideoManagementApi.Infrastructure.Context;
using VideoManagementApi.Infrastructure.Utilities;

namespace VideoManagementApi.Infrastructure.Services;

public class VideoService : IVideoService
{
    private readonly VideoContext _videoContext;
    private readonly IVideoRepository _videoRepository;
    private readonly IMapper _mapper;
    private readonly IClaimProvider _claimProvider;

    public VideoService(VideoContext videoContext, IMapper mapper, IVideoRepository videoRepository,
        IClaimProvider claimProvider)
    {
        _videoContext = videoContext;
        _mapper = mapper;
        _videoRepository = videoRepository;
        _claimProvider = claimProvider;
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
            IsActive = false
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
                File = updateVideoContentCommand.File,
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
        video.IsActive = true;
        await _videoRepository.UpdateAsync(video, cancellationToken);
        return await Result<int>.SuccessAsync(video.Id);
    }

    public async Task<IResult> UpdateAsync(UpdateVideoCommand updateVideoCommand, CancellationToken cancellationToken)
    {
        var video = await _videoContext.Videos.Include(a => a.Seos).Include(a => a.VideoAndCategories)
            .SingleOrDefaultAsync(a => a.Id == updateVideoCommand.Id,
                cancellationToken);
        if (video == null)
            return await Result.FailAsync();
        updateVideoCommand.Seos = await SetVideoIdToSeo(updateVideoCommand.Seos, updateVideoCommand.Id);
        updateVideoCommand.VideoAndCategories =
            await SetVideoIdToCategories(updateVideoCommand.VideoAndCategories, updateVideoCommand.Id);
        var newVideo = _mapper.Map<UpdateVideoCommand, Video>(updateVideoCommand, video);
        newVideo.IsActive = true;
        await _videoRepository.UpdateAsync(newVideo, cancellationToken);
        return await Result.SuccessAsync();
    }

    private async Task<List<CreateSeoCommand>> SetVideoIdToSeo(List<CreateSeoCommand> seos, int videoId)
    {
        foreach (var seo in seos)
        {
            seo.VideoId = videoId;
        }
        return await Task.FromResult(seos);
    }

    private async Task<List<CreateVideoAndCategoryCommand>> SetVideoIdToCategories(
        List<CreateVideoAndCategoryCommand> categories, int videoId)
    {
        foreach (var category in categories)
        {
            category.VideoId = videoId;
        }
        return await Task.FromResult(categories);
    }

    public async Task<IResult<List<Video>>> GetVideos(GetVideosQuery query, CancellationToken cancellationToken)
    {
        var videos = query.IsActive == null
            ? await _videoContext.Videos
                .AsNoTracking()
                .AsQueryable()
                .Include(a => a.Comments.Where(a => a.IsApproved))
                .Include(a => a.Likes)
                .Include(a => a.Seos)
                .Include(a => a.VideoAndCategories)
                .ToListAsync(cancellationToken)
            : await _videoContext.Videos
                .AsNoTracking()
                .AsQueryable()
                .Include(a => a.Comments.Where(a => a.IsApproved))
                .Include(a => a.Likes)
                .Include(a => a.Seos)
                .Include(a => a.VideoAndCategories)
                .Where(a => a.IsActive).ToListAsync(cancellationToken);
        return await Result<List<Video>>.SuccessAsync(videos);
    }

    public async Task<IResult> AddCountAsync(AddCountVideoCommand command, CancellationToken cancellationToken)
    {
        var video = await _videoRepository.GetByIdAsync(command.Id, cancellationToken);
        if (video == null)
            return await Result.FailAsync();
        video.WatchCount++;
        await _videoRepository.UpdateAsync(video, cancellationToken);
        return await Result.SuccessAsync();
    }
}