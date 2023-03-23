using VideoManagementApi.Dtos.CommentDtos;
using VideoManagementApi.Utilities;
using IResult = VideoManagementApi.Utilities.IResult;

namespace VideoManagementApi.Services.Abstract;

public interface ICommentService
{
    Task<IResult> AddAsync(CommentAddDto commentAddDto);
    Task<IResult<List<CommentDto>>> GetCommentsByVideoId(int videoId);
    Task<IResult> ApproveComment(int commentId,int adminId);
}