using VideoManagementApi.Application.Interfaces.Services;
using VideoManagementApi.Domain.Entities;

namespace VideoManagementApi.Application.Features.VideoAndCategoryFeatures.Queries;

public class
    GetCategoriesByVideoIdQueryHandler : IRequestHandler<GetCategoriesByVideoIdQuery, IResult<List<VideoAndCategory>>>
{
    private readonly IVideoAndCategoryService _videoAndCategoryService;

    public GetCategoriesByVideoIdQueryHandler(IVideoAndCategoryService videoAndCategoryService)
    {
        _videoAndCategoryService = videoAndCategoryService;
    }

    public async Task<IResult<List<VideoAndCategory>>> Handle(GetCategoriesByVideoIdQuery request,
        CancellationToken cancellationToken)
    {
        return await _videoAndCategoryService.GetCategoryiesByVideoId(request.VideoId, cancellationToken);
    }
}