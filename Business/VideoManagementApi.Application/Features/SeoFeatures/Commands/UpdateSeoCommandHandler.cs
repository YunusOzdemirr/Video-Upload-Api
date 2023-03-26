using VideoManagementApi.Application.Interfaces.Services;

namespace VideoManagementApi.Application.Features.SeoFeatures.Commands;

public class UpdateSeoCommandHandler : IRequestHandler<UpdateSeoCommand, IResult>
{
    private readonly ISeoService _seoService;

    public UpdateSeoCommandHandler(ISeoService seoService)
    {
        _seoService = seoService;
    }

    public async Task<IResult> Handle(UpdateSeoCommand request, CancellationToken cancellationToken)
    {
        return await _seoService.UpdateAsync(request, cancellationToken);
    }
}