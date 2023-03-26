namespace VideoManagementApi.Application.Features.CommentFeatures.Commands;

public class ApproveCommentCommand : IRequest<IResult>
{
    public int Id { get; set; }
    public int AdminId { get; set; }
}