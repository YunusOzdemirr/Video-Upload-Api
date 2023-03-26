namespace VideoManagementApi.Application.Features.LikeFeatures.Commands;

public class CreateOrUpdateLikeCommand : IRequest<IResult>
{
    public string IpAddress { get; set; }
    public int VideoId { get; set; }
    public bool IsLiked { get; set; }
}