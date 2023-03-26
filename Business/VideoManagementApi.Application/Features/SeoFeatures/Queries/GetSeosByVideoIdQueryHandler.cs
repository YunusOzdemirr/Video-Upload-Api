using VideoManagementApi.Application.Interfaces.Services;
using VideoManagementApi.Domain.Entities;

namespace VideoManagementApi.Application.Features.SeoFeatures.Queries;

public class GetSeosByVideoIdQueryHandler : IRequestHandler<GetSeosByVideoIdQuery, IResult<List<Seo>>>
{
    private readonly ISeoService _seoService;

    public GetSeosByVideoIdQueryHandler(ISeoService seoService)
    {
        _seoService = seoService;
    }

    public async Task<IResult<List<Seo>>> Handle(GetSeosByVideoIdQuery request, CancellationToken cancellationToken)
    {
        return await _seoService.GetSeosByVideoIdAsync(request.VideoId, cancellationToken);
    }
}