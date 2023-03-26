using VideoManagementApi.Application.Features.CommentFeatures.Commands;
using VideoManagementApi.Domain.Entities;

namespace VideoManagementApi.Application.Interfaces.Services;

public interface ICommentService
{
    Task<IResult> AddAsync(CreateCommentCommand command, CancellationToken cancellationToken);
    Task<IResult<List<Comment>>> GetCommentsByVideoIdAsync(int videoId, CancellationToken cancellationToken);
    Task<IResult> ApproveCommentAsync(int commentId, int adminId, CancellationToken cancellationToken);
    Task<IResult<Comment>> GetCommentByIdAsync(int commentId, CancellationToken cancellationToken);
}