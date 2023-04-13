namespace VideoManagementApi.Application.Features.SeoFeatures.Commands;

public class CreateSeoCommand : IRequest<IResult>
{
    public string Tag { get; set; }
    public string Description { get; set; }
    public string IpAddress { get; set; }
    public int VideoId { get; set; }
}