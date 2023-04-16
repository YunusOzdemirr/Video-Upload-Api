using VideoManagementApi.Application.Features.SeoFeatures.Commands;
using VideoManagementApi.Domain.Entities;

namespace VideoManagementApi.Application.Interfaces.Services;

public interface ISeoService
{
    Task<IResult> CreateAsync(CreateSeoCommand createSeoCommand, CancellationToken cancellationToken);
    Task<IResult> UpdateAsync(UpdateSeoCommand updateSeoCommand, CancellationToken cancellationToken);
    Task<IResult<List<Seo>>> GetSeosByVideoIdAsync(int videoId, CancellationToken cancellationToken);
    Task<IResult> DeleteSeoByVideoId(int videoId, int seoId, CancellationToken cancellationToken);
}