using AutoMapper;
using Microsoft.EntityFrameworkCore;
using VideoManagementApi.Application.Features.LikeFeatures.Commands;
using VideoManagementApi.Application.Features.LikeFeatures.Queries;
using VideoManagementApi.Application.Interfaces.Services;
using VideoManagementApi.Domain.Common;
using VideoManagementApi.Domain.Entities;
using VideoManagementApi.Infrastructure.Context;

namespace VideoManagementApi.Infrastructure.Services;

public class LikeService : ILikeService
{
    private readonly VideoContext _videoContext;
    private readonly ILikeRepository _likeRepository;
    private readonly IMapper _mapper;


    public LikeService(ILikeRepository likeRepository, VideoContext videoContext, IMapper mapper)
    {
        _videoContext = videoContext;
        _likeRepository = likeRepository;
        _mapper = mapper;
    }

    public async Task<IResult> CreateOrUpdateAsync(CreateOrUpdateLikeCommand createLikeCommand,
        CancellationToken cancellationToken)
    {
        var video = await _videoContext.Videos.Include(a => a.Likes)
            .SingleOrDefaultAsync(a => a.Id == createLikeCommand.VideoId, cancellationToken);
        if (video == null)
            return await Result.FailAsync();
        var like = _mapper.Map<Like>(createLikeCommand);
        like.Video = video;
        if (video?.Likes?.Any(a => a.IpAddress == createLikeCommand.IpAddress && a.IsLiked) == true)
        {
            var oldLike = video.Likes.SingleOrDefault(a => a.IpAddress == createLikeCommand.IpAddress);
            video.Likes.Remove(oldLike!);
        }

        video.Likes?.Add(like);
        video.ModifiedDate = DateTime.Now;
        await _likeRepository.AddAsync(like, cancellationToken);
        await _videoContext.SaveChangesAsync(cancellationToken);
        return await Result.SuccessAsync();
    }

    public async Task<IResult<List<Like>>> GetAllAsync(GetLikesQuery getLikesQuery, CancellationToken cancellationToken)
    {
        var video = await _videoContext
            .Videos
            .Include(a => a.Likes)
            .SingleOrDefaultAsync(a => a.Id == getLikesQuery.VideoId, cancellationToken);
        return await Result<List<Like>>.SuccessAsync(video.Likes.ToList());
    }
}