using VideoManagementApi.Application.Interfaces.Services;

namespace VideoManagementApi.Application.Features.VideoAndCategoryFeatures.Commands;

public class CreateVideoAndCategoryCommandHandler : IRequestHandler<CreateVideoAndCategoryCommand, IResult>
{
    private readonly IVideoAndCategoryService _videoAndCategoryService;

    public CreateVideoAndCategoryCommandHandler(IVideoAndCategoryService videoAndCategoryService)
    {
        _videoAndCategoryService = videoAndCategoryService;
    }

    public async Task<IResult> Handle(CreateVideoAndCategoryCommand request, CancellationToken cancellationToken)
    {
        return await _videoAndCategoryService.CreateAsync(request, cancellationToken);
    }
}