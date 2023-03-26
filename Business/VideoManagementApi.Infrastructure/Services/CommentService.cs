using AutoMapper;
using Microsoft.EntityFrameworkCore;
using VideoManagementApi.Application.Features.CommentFeatures.Commands;
using VideoManagementApi.Application.Interfaces.Services;
using VideoManagementApi.Domain.Common;
using VideoManagementApi.Domain.Entities;
using VideoManagementApi.Infrastructure.Context;

namespace VideoManagementApi.Infrastructure.Services;

public class CommentService : ICommentService
{
    private readonly VideoContext _videoContext;
    private readonly ICommentRepository _commentRepository;
    private readonly IMapper _mapper;

    public CommentService(IMapper mapper, VideoContext videoContext, ICommentRepository commentRepository)
    {
        _mapper = mapper;
        _videoContext = videoContext;
        _commentRepository = commentRepository;
    }

    public async Task<IResult> AddAsync(CreateCommentCommand command, CancellationToken cancellationToken)
    {
        var video = await _videoContext.Videos.SingleOrDefaultAsync(a => a.Id == command.VideoId);
        if (video == null)
            return await Result.FailAsync();
        var comment = _mapper.Map<Comment>(command);
        comment.Video = video;
        comment.CreatedDate = DateTime.Now;
        video.Comments.Add(comment);
        await _commentRepository.AddAsync(comment);
        return await Result.SuccessAsync();
    }

    public async Task<IResult<List<Comment>>> GetCommentsByVideoIdAsync(int videoId,
        CancellationToken cancellationToken)
    {
        var video = await _videoContext.Videos.AsNoTracking().Include(a => a.Comments.Where(a => a.IsApproved))
            .SingleOrDefaultAsync(a => a.Id == videoId);
        var comments = video.Comments.ToList();
        return await Result<List<Comment>>.SuccessAsync(comments);
    }

    public async Task<IResult> ApproveCommentAsync(int commentId, int adminId, CancellationToken cancellationToken)
    {
        var comment = await _videoContext.Comments.AsNoTracking().SingleOrDefaultAsync(a => a.Id == commentId);
        if (comment == null)
            return await Result.FailAsync();
        comment.IsApproved = comment.IsApproved ? false : true;
        comment.ModifiedDate = DateTime.Now;
        comment.ModifiedBy = adminId;
        await _commentRepository.UpdateAsync(comment);
        return await Result.SuccessAsync();
    }

    public async Task<IResult<Comment>> GetCommentByIdAsync(int commentId, CancellationToken cancellationToken)
    {
        var comment = await _commentRepository.GetByIdAsync(commentId);
        return await Result<Comment>.SuccessAsync(comment);
    }
}