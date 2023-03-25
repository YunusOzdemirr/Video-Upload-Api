using MediatR;
using VideoManagementApi.Models;
using VideoManagementApi.Utilities;
using IResult = VideoManagementApi.Utilities.IResult;

namespace VideoManagementApi.Features.Queries.CommentsQueries;

public class GetCommentQuery : IRequest<IResult<Comment>>
{
    public int Id { get; set; }
}