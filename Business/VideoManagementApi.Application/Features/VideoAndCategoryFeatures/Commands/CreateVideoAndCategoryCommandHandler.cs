namespace VideoManagementApi.Application.Features.VideoAndCategoryFeatures.Commands;

public class CreateVideoAndCategoryCommandHandler : IRequestHandler<CreateVideoAndCategoryCommand, IResult>
{
    public async Task<IResult> Handle(CreateVideoAndCategoryCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}