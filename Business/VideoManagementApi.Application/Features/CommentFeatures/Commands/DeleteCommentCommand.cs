namespace VideoManagementApi.Application.Features.CommentFeatures.Commands;

public class DeleteCommentCommand : IRequest<IResult>
{
    public int Id { get; set; }
}