using VideoManagementApi.Application.Interfaces.Services;
using VideoManagementApi.Domain.Entities;

namespace VideoManagementApi.Application.Features.CommentFeatures.Queries;

public class GetCommentsQueryHandler : IRequestHandler<GetCommentsQuery, IResult<List<Comment>>>
{
    private readonly ICommentService _commentService;

    public GetCommentsQueryHandler(ICommentService commentService)
    {
        _commentService = commentService;
    }

    public async Task<IResult<List<Comment>>> Handle(GetCommentsQuery request, CancellationToken cancellationToken)
    {
        return await _commentService.GetCommentsByVideoIdAsync(request.VideoId, cancellationToken);
    }
}