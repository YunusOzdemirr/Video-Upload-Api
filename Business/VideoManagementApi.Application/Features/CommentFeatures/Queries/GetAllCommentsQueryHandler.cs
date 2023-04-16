using VideoManagementApi.Domain.Entities;

namespace VideoManagementApi.Application.Features.CommentFeatures.Queries;

public class GetAllCommentsQueryHandler : IRequestHandler<GetAllCommentsQuery, IResult<List<Comment>>>
{
    private readonly ICommentRepository _commentRepository;

    public GetAllCommentsQueryHandler(ICommentRepository commentRepository)
    {
        _commentRepository = commentRepository;
    }

    public async Task<IResult<List<Comment>>> Handle(GetAllCommentsQuery request, CancellationToken cancellationToken)
    {
        var result = await _commentRepository.GetAllAsync(cancellationToken: cancellationToken);
        if (result.Any())
            return await Result<List<Comment>>.SuccessAsync(result);
        return await Result<List<Comment>>.FailAsync(result);
    }
}