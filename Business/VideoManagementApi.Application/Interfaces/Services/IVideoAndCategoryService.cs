using VideoManagementApi.Application.Features.VideoAndCategoryFeatures.Commands;
using VideoManagementApi.Domain.Entities;

namespace VideoManagementApi.Application.Interfaces.Services;

public interface IVideoAndCategoryService
{
    Task<IResult> CreateAsync(CreateVideoAndCategoryCommand createVideoAndCategoryCommand,
        CancellationToken cancellationToken);

    Task<IResult> DeleteAsync(DeleteVideoAndCategoryCommand deleteVideoAndCategoryCommand,
        CancellationToken cancellationToken);

    Task<IResult<List<VideoAndCategory>>> GetVideosByCategoryId(int categoryId, CancellationToken cancellationToken);
    Task<IResult<List<VideoAndCategory>>> GetCategoryiesByVideoId(int videoId, CancellationToken cancellationToken);
}