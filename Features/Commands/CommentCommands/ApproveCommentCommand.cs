using MediatR;
using IResult = VideoManagementApi.Utilities.IResult;

namespace VideoManagementApi.Features.Commands.CommentCommands;

public class ApproveCommentCommand : IRequest<IResult>
{
    public int Id { get; set; }
    public int AdminId { get; set; }
}