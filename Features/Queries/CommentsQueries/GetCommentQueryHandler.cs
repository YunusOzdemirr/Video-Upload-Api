using MediatR;
using VideoManagementApi.Models;
using VideoManagementApi.Services.Abstract;
using VideoManagementApi.Utilities;

namespace VideoManagementApi.Features.Queries.CommentsQueries;

public class GetCommentQueryHandler : IRequestHandler<GetCommentQuery, IResult<Comment>>
{
    private readonly ICommentService _commentService;

    public GetCommentQueryHandler(ICommentService commentService)
    {
        _commentService = commentService;
    }

    public async Task<IResult<Comment>> Handle(GetCommentQuery request, CancellationToken cancellationToken)
    {
        return await _commentService.GetCommentByIdAsync(request.Id);
    }
}