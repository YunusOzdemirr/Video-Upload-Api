using VideoManagementApi.Application.Interfaces.Services;

namespace VideoManagementApi.Application.Features.SeoFeatures.Commands;

public class DeleteSeoByVideoIdCommandHandler : IRequestHandler<DeleteSeoByVideoIdCommand, IResult>
{
    private readonly ISeoService _seoService;

    public DeleteSeoByVideoIdCommandHandler(ISeoService seoService)
    {
        _seoService = seoService;
    }

    public async Task<IResult> Handle(DeleteSeoByVideoIdCommand request, CancellationToken cancellationToken)
    {
        return await _seoService.DeleteSeoByVideoId(request.VideoId, request.SeoId, cancellationToken);
    }
}