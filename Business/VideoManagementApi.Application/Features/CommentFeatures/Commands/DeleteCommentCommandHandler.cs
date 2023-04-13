namespace VideoManagementApi.Application.Features.CommentFeatures.Commands;

public class DeleteCommentCommandHandler : IRequestHandler<DeleteCommentCommand, IResult>
{
    private readonly ICommentRepository _repository;

    public DeleteCommentCommandHandler(ICommentRepository repository)
    {
        _repository = repository;
    }

    public async Task<IResult> Handle(DeleteCommentCommand request, CancellationToken cancellationToken)
    {
        var result= await _repository.DeleteByIdAsync(request.Id, cancellationToken);
        if (result)
            return await Result.SuccessAsync();
        return await Result.FailAsync();
    }
}