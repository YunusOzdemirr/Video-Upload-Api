using VideoManagementApi.Application.Interfaces.Services;

namespace VideoManagementApi.Application.Features.CommentFeatures.Commands;

public class CreateCommentCommandHandler : IRequestHandler<CreateCommentCommand, IResult>
{
    private readonly ICommentService _commentService;

    public CreateCommentCommandHandler(ICommentService commentService)
    {
        _commentService = commentService;
    }

    public async Task<IResult> Handle(CreateCommentCommand request, CancellationToken cancellationToken)
    {
        var result = await _commentService.AddAsync(request, cancellationToken);
        return result;
    }
}