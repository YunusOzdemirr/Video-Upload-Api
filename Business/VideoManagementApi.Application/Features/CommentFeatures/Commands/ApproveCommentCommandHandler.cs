using VideoManagementApi.Application.Interfaces.Services;

namespace VideoManagementApi.Application.Features.CommentFeatures.Commands;

public class ApproveCommentCommandHandler : IRequestHandler<ApproveCommentCommand, IResult>
{
    private readonly ICommentService _commentService;

    public ApproveCommentCommandHandler(ICommentService commentService)
    {
        _commentService = commentService;
    }

    public async Task<IResult> Handle(ApproveCommentCommand request, CancellationToken cancellationToken)
    {
        return await _commentService.ApproveCommentAsync(request.Id, request.AdminId, cancellationToken);
    }
}