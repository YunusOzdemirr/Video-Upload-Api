using VideoManagementApi.Application.Interfaces.Services;
using VideoManagementApi.Domain.Entities;

namespace VideoManagementApi.Application.Features.CommentFeatures.Queries;

public class GetCommentQueryHandler : IRequestHandler<GetCommentQuery, IResult<Comment>>
{
    private readonly ICommentService _commentService;

    public GetCommentQueryHandler(ICommentService commentService)
    {
        _commentService = commentService;
    }

    public async Task<IResult<Comment>> Handle(GetCommentQuery request, CancellationToken cancellationToken)
    {
        return await _commentService.GetCommentByIdAsync(request.Id, cancellationToken);
    }
}