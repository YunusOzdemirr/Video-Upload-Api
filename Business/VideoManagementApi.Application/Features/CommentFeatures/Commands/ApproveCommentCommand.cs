namespace VideoManagementApi.Application.Features.CommentFeatures.Commands;

public class ApproveCommentCommand : IRequest<IResult>
{
    public string IpAddress { get; set; }
    public int Id { get; set; }
    public int AdminId { get; set; }
}