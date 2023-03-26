using VideoManagementApi.Application.Interfaces.Services;

namespace VideoManagementApi.Application.Features.SeoFeatures.Commands;

public class CreateSeoCommandHandler : IRequestHandler<CreateSeoCommand, IResult>
{
    private readonly ISeoService _seoService;

    public CreateSeoCommandHandler(ISeoService seoService)
    {
        _seoService = seoService;
    }

    public async Task<IResult> Handle(CreateSeoCommand request, CancellationToken cancellationToken)
    {
        return await _seoService.CreateAsync(request, cancellationToken);
    }
}