using VideoManagementApi.Application.Interfaces.Services;
using VideoManagementApi.Domain.Entities;

namespace VideoManagementApi.Application.Features.VideoAndCategoryFeatures.Queries;

public class
    GetVideosByCategoryIdQueryHandler : IRequestHandler<GetVideosByCategoryIdQuery, IResult<List<VideoAndCategory>>>
{
    private readonly IVideoAndCategoryService _videoAndCategoryService;

    public GetVideosByCategoryIdQueryHandler(IVideoAndCategoryService videoAndCategoryService)
    {
        _videoAndCategoryService = videoAndCategoryService;
    }

    public async Task<IResult<List<VideoAndCategory>>> Handle(GetVideosByCategoryIdQuery request,
        CancellationToken cancellationToken)
    {
        return await _videoAndCategoryService.GetVideosByCategoryId(request.CategoryId, cancellationToken);
    }
}