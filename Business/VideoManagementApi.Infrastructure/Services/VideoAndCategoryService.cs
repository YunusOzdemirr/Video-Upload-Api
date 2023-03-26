using AutoMapper;
using Microsoft.EntityFrameworkCore;
using VideoManagementApi.Application.Features.VideoAndCategoryFeatures.Commands;
using VideoManagementApi.Application.Interfaces.Services;
using VideoManagementApi.Domain.Common;
using VideoManagementApi.Domain.Entities;
using VideoManagementApi.Infrastructure.Context;

namespace VideoManagementApi.Infrastructure.Services;

public class VideoAndCategoryService : IVideoAndCategoryService
{
    private readonly VideoContext _videoContext;
    private readonly IVideoAndCategoryRepository _videoAndCategoryRepository;

    public VideoAndCategoryService(VideoContext videoContext, IVideoAndCategoryRepository videoAndCategoryRepository)
    {
        _videoContext = videoContext;
        _videoAndCategoryRepository = videoAndCategoryRepository;
    }

    public async Task<IResult> CreateAsync(CreateVideoAndCategoryCommand createVideoAndCategoryCommand,
        CancellationToken cancellationToken)
    {
        var video = await _videoContext
            .Videos
            .Include(a => a.VideoAndCategories)
            .SingleOrDefaultAsync(a => a.Id == createVideoAndCategoryCommand.VideoId, cancellationToken);
        if (video == null)
            return await Result.FailAsync();
        var category = await _videoContext
            .Categories
            .Include(a => a.VideoAndCategories)
            .SingleOrDefaultAsync(a => a.Id == createVideoAndCategoryCommand.CategoryId, cancellationToken);
        if (category == null)
            return await Result.FailAsync();
        var videoAndCategory = new VideoAndCategory()
        {
            Video = video,
            VideoId = video.Id,
            CategoryId = category.Id,
            Category = category
        };
        video.VideoAndCategories.Add(videoAndCategory);
        category.VideoAndCategories.Add(videoAndCategory);
        await _videoAndCategoryRepository.AddAsync(videoAndCategory, cancellationToken);
        await _videoContext.SaveChangesAsync(cancellationToken);
        return await Result.SuccessAsync();
    }

    public async Task<IResult> DeleteAsync(DeleteVideoAndCategoryCommand deleteVideoAndCategoryCommand,
        CancellationToken cancellationToken)
    {
        var videoAndCategory = await _videoContext
            .VideoAndCategories
            .Include(a => a.Video)
            .Include(a => a.Category)
            .SingleOrDefaultAsync(a =>
                a.VideoId == deleteVideoAndCategoryCommand.VideoId &&
                a.CategoryId == deleteVideoAndCategoryCommand.CategoryId, cancellationToken);
        if (videoAndCategory == null)
            return await Result.FailAsync();
        videoAndCategory.Video.VideoAndCategories.Remove(videoAndCategory);
        videoAndCategory.Category.VideoAndCategories.Remove(videoAndCategory);
        _videoContext.Remove(videoAndCategory);
        await _videoContext.SaveChangesAsync(cancellationToken);
        return await Result.SuccessAsync();
    }

    public async Task<IResult<List<VideoAndCategory>>> GetVideosByCategoryId(int categoryId,
        CancellationToken cancellationToken)
    {
        var videos = await _videoContext
            .VideoAndCategories
            .Include(a => a.Video)
            .Where(a => a.CategoryId == categoryId && a.IsActive).ToListAsync(cancellationToken);
        return await Result<List<VideoAndCategory>>.SuccessAsync(videos);
    }

    public async Task<IResult<List<VideoAndCategory>>> GetCategoryiesByVideoId(int videoId,
        CancellationToken cancellationToken)
    {
        var videos = await _videoContext
            .VideoAndCategories
            .Include(a => a.Category)
            .Where(a => a.VideoId ==videoId && a.IsActive).ToListAsync(cancellationToken);
        return await Result<List<VideoAndCategory>>.SuccessAsync(videos);
    }
}