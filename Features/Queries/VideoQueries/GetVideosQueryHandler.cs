using MediatR;
using VideoManagementApi.Dtos.VideoDtos;
using VideoManagementApi.Models;
using VideoManagementApi.Services.Abstract;
using VideoManagementApi.Utilities;

namespace VideoManagementApi.Features.Queries.VideoQueries;

public class GetVideosQueryHandler : IRequestHandler<GetVideosQuery, IResult<List<Video>>>
{
    private readonly IUploadService _uploadService;

    public GetVideosQueryHandler(IUploadService uploadService)
    {
        _uploadService = uploadService;
    }

    public async Task<IResult<List<Video>>> Handle(GetVideosQuery request, CancellationToken cancellationToken)
    {
        var result = await _uploadService.GetVideos(request);
        return result;
    }
}