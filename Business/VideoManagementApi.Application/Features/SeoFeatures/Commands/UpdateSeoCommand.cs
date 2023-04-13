namespace VideoManagementApi.Application.Features.SeoFeatures.Commands;

public class UpdateSeoCommand : IRequest<IResult>
{
    public int Id { get; set; }
    public string Tag { get; set; }
    public string Description { get; set; }
    public string IpAddress { get; set; }
    public int VideoId { get; set; }
}