using VideoManagementApi.Domain.Entities;

namespace VideoManagementApi.Application.Features.SeoFeatures.Queries;

public class GetSeosByVideoIdQuery : IRequest<IResult<List<Seo>>>
{
    public int VideoId { get; set; }
}