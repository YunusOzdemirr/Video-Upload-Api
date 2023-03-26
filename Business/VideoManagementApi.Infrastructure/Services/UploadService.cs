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

public class UploadService : IUploadService
{
    private readonly VideoContext _videoContext;
    private readonly IVideoRepository _videoRepository;
    private readonly IMapper _mapper;
    private readonly IMediator _mediator;

    public UploadService(VideoContext videoContext, IMapper mapper, IVideoRepository videoRepository,
        IMediator mediator)
    {
        _videoContext = videoContext;
        _mapper = mapper;
        _videoRepository = videoRepository;
        _mediator = mediator;
    }

    public async Task<IResult> UploadAsync(CreateVideoCommand createVideoCommand, CancellationToken cancellationToken)
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
        };
        await _videoRepository.AddAsync(video, cancellationToken);
        await SeoAndCategoryCreateAsync(createVideoCommand.VideoAndCategories, createVideoCommand.Seos, video.Id);
        return await Result.SuccessAsync();
    }

    private async Task SeoAndCategoryCreateAsync(List<CreateVideoAndCategoryCommand> videoAndCategories,
        List<CreateSeoCommand> seos, int videoId)
    {
        if (videoAndCategories.Count > 0)
            foreach (var videoAndCategory in videoAndCategories)
            {
                videoAndCategory.VideoId = videoId;
                await _mediator.Send(videoAndCategory);
            }

        if (seos.Count > 0)
            foreach (var seo in seos)
            {
                seo.VideoId = videoId;
                await _mediator.Send(seo);
            }
    }

    public async Task<IResult> UpdateAsync(UpdateVideoCommand updateVideoCommand, CancellationToken cancellationToken)
    {
        var video = await _videoContext.Videos.SingleOrDefaultAsync(a => a.Id == updateVideoCommand.Id,
            cancellationToken);
        if (video == null)
            return await Result.FailAsync();
        var newVideo = _mapper.Map<UpdateVideoCommand, Video>(updateVideoCommand, video);
        await _videoRepository.UpdateAsync(newVideo, cancellationToken);
        await SeoAndCategoryCreateAsync(updateVideoCommand.VideoAndCategories, updateVideoCommand.Seos, video.Id);
        return await Result.SuccessAsync();
    }

    public async Task<IResult<List<Video>>> GetVideos(GetVideosQuery query, CancellationToken cancellationToken)
    {
        var videos = query.IsActive == null
            ? await _videoRepository.GetAllAsync(cancellationToken: cancellationToken)
            : await _videoRepository.GetAllAsync(a => a.IsActive == query.IsActive, cancellationToken);
        return await Result<List<Video>>.SuccessAsync(videos);
    }
}