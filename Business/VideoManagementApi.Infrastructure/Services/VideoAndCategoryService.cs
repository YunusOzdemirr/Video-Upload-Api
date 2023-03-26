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
    private readonly IMapper _mapper;

    public VideoAndCategoryService(VideoContext videoContext, IVideoAndCategoryRepository videoAndCategoryRepository,
        IMapper mapper)
    {
        _videoContext = videoContext;
        _videoAndCategoryRepository = videoAndCategoryRepository;
        _mapper = mapper;
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
        await _videoAndCategoryRepository.AddAsync(videoAndCategory, cancellationToken);

        return await Result.SuccessAsync();
    }

    public async Task<IResult> DeleteAsync(DeleteVideoAndCategoryCommand deleteVideoAndCategoryCommand,
        CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public async Task<IResult<List<VideoAndCategory>>> GetVideosByCategoryId(int categoryId,
        CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public async Task<IResult<List<VideoAndCategory>>> GetCategoryiesByVideoId(int videoId,
        CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}