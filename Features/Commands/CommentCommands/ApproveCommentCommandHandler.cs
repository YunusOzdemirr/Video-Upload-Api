using MediatR;
using VideoManagementApi.Services.Abstract;
using IResult = VideoManagementApi.Utilities.IResult;

namespace VideoManagementApi.Features.Commands.CommentCommands;

public class ApproveCommentCommandHandler : IRequestHandler<ApproveCommentCommand, IResult>
{
    private readonly ICommentService _commentService;

    public ApproveCommentCommandHandler(ICommentService commentService)
    {
        _commentService = commentService;
    }

    public async Task<IResult> Handle(ApproveCommentCommand request, CancellationToken cancellationToken)
    {
        return await _commentService.ApproveCommentAsync(request.Id, request.AdminId);
    }
}