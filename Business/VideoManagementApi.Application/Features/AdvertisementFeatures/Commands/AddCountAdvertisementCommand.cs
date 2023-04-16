using VideoManagementApi.Domain.Enums;

namespace VideoManagementApi.Application.Features.AdvertisementFeatures.Commands;

public class AddCountAdvertisementCommand : IRequest<IResult>
{
    public int Id { get; set; }
    public CountType CountType { get; set; }
}