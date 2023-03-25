using MediatR;
using VideoManagementApi.Models;
using VideoManagementApi.Services.Abstract;
using VideoManagementApi.Utilities;

namespace VideoManagementApi.Features.Queries.CommentsQueries;

public class GetCommentsQueryHandler : IRequestHandler<GetCommentsQuery, IResult<List<Comment>>>
{
    private readonly ICommentService _commentService;

    public GetCommentsQueryHandler(ICommentService commentService)
    {
        _commentService = commentService;
    }

    public async Task<IResult<List<Comment>>> Handle(GetCommentsQuery request, CancellationToken cancellationToken)
    {
        return await _commentService.GetCommentsByVideoIdAsync(request.VideoId);
    }
}