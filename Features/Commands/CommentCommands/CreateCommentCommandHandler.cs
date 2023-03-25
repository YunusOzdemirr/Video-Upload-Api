using MediatR;
using VideoManagementApi.Services.Abstract;
using IResult = VideoManagementApi.Utilities.IResult;

namespace VideoManagementApi.Features.Commands.CommentCommands;

public class CreateCommentCommandHandler : IRequestHandler<CreateCommentCommand, IResult>
{
    private readonly ICommentService _commentService;

    public CreateCommentCommandHandler(ICommentService commentService)
    {
        _commentService = commentService;
    }

    public async Task<IResult> Handle(CreateCommentCommand request, CancellationToken cancellationToken)
    {
        var result = await _commentService.AddAsync(request);
        return result;
    }
}