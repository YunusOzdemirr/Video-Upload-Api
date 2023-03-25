using VideoManagementApi.Dtos.CommentDtos;
using VideoManagementApi.Features.Commands.CommentCommands;
using VideoManagementApi.Models;
using VideoManagementApi.Utilities;
using IResult = VideoManagementApi.Utilities.IResult;

namespace VideoManagementApi.Services.Abstract;

public interface ICommentService
{
    Task<IResult> AddAsync(CreateCommentCommand command);
    Task<IResult<List<Comment>>> GetCommentsByVideoIdAsync(int videoId);
    Task<IResult> ApproveCommentAsync(int commentId,int adminId);
    Task<IResult<Comment>> GetCommentByIdAsync(int commentId);
}