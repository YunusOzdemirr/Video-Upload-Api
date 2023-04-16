namespace VideoManagementApi.Application.Features.SeoFeatures.Commands;

public class DeleteSeoByVideoIdCommand : IRequest<IResult>
{
    public int VideoId { get; set; }
    public int SeoId { get; set; }
}