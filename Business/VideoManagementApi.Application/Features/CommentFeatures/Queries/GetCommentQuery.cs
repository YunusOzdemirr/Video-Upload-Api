using VideoManagementApi.Domain.Entities;

namespace VideoManagementApi.Application.Features.CommentFeatures.Queries;

public class GetCommentQuery : IRequest<IResult<Comment>>
{
    public int Id { get; set; }
}