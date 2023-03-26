using VideoManagementApi.Application.Features.AdvertisementFeatures.Commands;
using VideoManagementApi.Application.Features.AdvertisementFeatures.Queries;
using VideoManagementApi.Domain.Entities;

namespace VideoManagementApi.Application.Interfaces.Services;

public interface IAdvertisementService
{
    Task<IResult> CreateAsync(CreateAdvertisementCommand createAdvertisementCommand,
        CancellationToken cancellationToken);
    
    Task<IResult> UpdateAsync(UpdateAdvertisementCommand updateAdvertisementCommand,
        CancellationToken cancellationToken);

    Task<IResult<List<Advertisement>>> GetAllAsync(GetAdvertisementsQuery getAdvertisementsQuery,
        CancellationToken cancellationToken);
}