using MediatR;
using VideoManagementApi.Models;
using VideoManagementApi.Utilities;

namespace VideoManagementApi.Features.Queries.CommentsQueries;

public class GetCommentsQuery : IRequest<IResult<List<Comment>>>
{
    public int VideoId { get; set; }
}