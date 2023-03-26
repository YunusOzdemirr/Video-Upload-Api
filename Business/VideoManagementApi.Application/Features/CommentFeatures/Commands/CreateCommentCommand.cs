namespace VideoManagementApi.Application.Features.CommentFeatures.Commands;

public abstract class CreateCommentCommand : IRequest<IResult>
{
    public string IpAddress { get; set; }
    public string Name { get; set; }
    public string Content { get; set; }
    public bool IsApproved { get; set; }
    public int VideoId { get; set; }
}