namespace VideoManagementApi.Application.Features.AdvertisementFeatures.Commands;

public class DeleteAdvertisementCommand : IRequest<IResult>
{
    public int Id { get; set; }
}