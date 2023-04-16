using VideoManagementApi.Domain.Entities;

namespace VideoManagementApi.Application.Features.CommentFeatures.Queries;

public class GetCommentsQuery : IRequest<IResult<List<Comment>>>
{
    public int VideoId { get; set; }
}

public class GetAllCommentsQuery : IRequest<IResult<List<Comment>>>
{
}