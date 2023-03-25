using AutoMapper;
using Microsoft.EntityFrameworkCore;
using VideoManagementApi.DataAccess.EntityFramework;
using VideoManagementApi.DataAccess.Repositories.Abstract;
using VideoManagementApi.Dtos.CommentDtos;
using VideoManagementApi.Features.Commands.CommentCommands;
using VideoManagementApi.Models;
using VideoManagementApi.Services.Abstract;
using VideoManagementApi.Utilities;
using IResult = VideoManagementApi.Utilities.IResult;

namespace VideoManagementApi.Services;

public class CommentService : ICommentService
{
    private VideoContext _videoContext;
    private ICommentRepository _commentRepository;
    private IMapper _mapper;

    public CommentService(IMapper mapper, VideoContext videoContext, ICommentRepository commentRepository)
    {
        _mapper = mapper;
        _videoContext = videoContext;
        _commentRepository = commentRepository;
    }

    public async Task<IResult> AddAsync(CreateCommentCommand command)
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

    public async Task<IResult<List<Comment>>> GetCommentsByVideoIdAsync(int videoId)
    {
        var video = await _videoContext.Videos.AsNoTracking().Include(a => a.Comments.Where(a => a.IsApproved))
            .SingleOrDefaultAsync(a => a.Id == videoId);
        var comments = video.Comments.ToList();
        return await Result<List<Comment>>.SuccessAsync(comments);
    }

    public async Task<IResult> ApproveCommentAsync(int commentId, int adminId)
    {
        var comment = await _videoContext.Comments.AsNoTracking().SingleOrDefaultAsync(a => a.Id == commentId);
        if (comment == null)
            return await Result.FailAsync();
        comment.IsApproved = comment.IsApproved ? false : true;
        comment.ModifyDate = DateTime.Now;
        comment.ModifiedBy = adminId;
        await _commentRepository.UpdateAsync(comment);
        return await Result.SuccessAsync();
    }

    public async Task<IResult<Comment>> GetCommentByIdAsync(int commentId)
    {
        var comment = await _commentRepository.GetByIdAsync(commentId);
        return await Result<Comment>.SuccessAsync(comment);
    }
}