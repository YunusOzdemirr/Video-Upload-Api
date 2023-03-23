using AutoMapper;
using Microsoft.EntityFrameworkCore;
using VideoManagementApi.DataAccess.EntityFramework;
using VideoManagementApi.Dtos.CommentDtos;
using VideoManagementApi.Models;
using VideoManagementApi.Services.Abstract;
using VideoManagementApi.Utilities;
using IResult = VideoManagementApi.Utilities.IResult;

namespace VideoManagementApi.Services;

public class CommentService : ICommentService
{
    private VideoContext _videoContext;
    private IMapper _mapper;

    public CommentService(IMapper mapper, VideoContext videoContext)
    {
        _mapper = mapper;
        _videoContext = videoContext;
    }

    public async Task<IResult> AddAsync(CommentAddDto commentAddDto)
    {
        var video = await _videoContext.Videos.SingleOrDefaultAsync(a => a.Id == commentAddDto.VideoId);
        if (video == null)
            return await Result.FailAsync();
        var comment = _mapper.Map<Comment>(commentAddDto);
        comment.Video = video;
        comment.CreatedDate = DateTime.Now;
        video.Comments.Add(comment);
        await _videoContext.Comments.AddAsync(comment);
        await _videoContext.SaveChangesAsync();
        return await Result.SuccessAsync();
    }

    public async Task<IResult<List<CommentDto>>> GetCommentsByVideoId(int videoId)
    {
        var video = await _videoContext.Videos.AsNoTracking().Include(a => a.Comments.Where(a => a.IsApproved))
            .SingleOrDefaultAsync(a => a.Id == videoId);
        var commentDtos = _mapper.Map<List<CommentDto>>(video.Comments);
        return await Result<List<CommentDto>>.SuccessAsync(commentDtos);
    }

    public async Task<IResult> ApproveComment(int commentId, int adminId)
    {
        var comment = await _videoContext.Comments.AsNoTracking().SingleOrDefaultAsync(a => a.Id == commentId);
        if (comment == null)
            return await Result.FailAsync();
        comment.IsApproved = comment.IsApproved ? false : true;
        comment.ModifyDate=DateTime.Now;
        comment.ModifiedBy = adminId;
        _videoContext.Comments.Update(comment);
        await _videoContext.SaveChangesAsync();
        return await Result.SuccessAsync();
    }
}