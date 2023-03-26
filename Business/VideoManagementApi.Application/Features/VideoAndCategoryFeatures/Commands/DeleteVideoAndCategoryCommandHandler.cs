using VideoManagementApi.Application.Interfaces.Services;

namespace VideoManagementApi.Application.Features.VideoAndCategoryFeatures.Commands;

public class DeleteVideoAndCategoryCommandHandler : IRequestHandler<DeleteVideoAndCategoryCommand, IResult>
{
    private readonly IVideoAndCategoryService _videoAndCategoryService;

    public DeleteVideoAndCategoryCommandHandler(IVideoAndCategoryService videoAndCategoryService)
    {
        _videoAndCategoryService = videoAndCategoryService;
    }

    public async Task<IResult> Handle(DeleteVideoAndCategoryCommand request, CancellationToken cancellationToken)
    {
        return await _videoAndCategoryService.DeleteAsync(request, cancellationToken);
    }
}