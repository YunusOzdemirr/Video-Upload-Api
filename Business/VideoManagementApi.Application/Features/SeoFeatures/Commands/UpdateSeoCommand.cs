namespace VideoManagementApi.Application.Features.SeoFeatures.Commands;

public class UpdateSeoCommand : IRequest<IResult>
{
    public string Tag { get; set; }
    public string Description { get; set; }
    public int VideoId { get; set; }
}