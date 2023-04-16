namespace VideoManagementApi.Application.Features.AdvertisementFeatures.Commands;

public class ChangeStatusAdvertisementCommand : IRequest<IResult>
{
    public int Id { get; set; }
    public bool IsActive { get; set; }
}