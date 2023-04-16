using VideoManagementApi.Application.Features.AdvertisementFeatures.Commands;
using VideoManagementApi.Application.Features.AdvertisementFeatures.Queries;
using VideoManagementApi.Domain.Entities;

namespace VideoManagementApi.Application.Interfaces.Services;

public interface IAdvertisementService
{
    Task<IResult<int>> CreateAsync(CreateAdvertisementCommand createAdvertisementCommand,
        CancellationToken cancellationToken);

    Task<IResult> UpdateAsync(UpdateAdvertisementCommand updateAdvertisementCommand,
        CancellationToken cancellationToken);

    Task<IResult<List<Advertisement>>> GetAllAsync(GetAllAdvertisementsQuery getAdvertisementsQuery,
        CancellationToken cancellationToken);

    Task<IResult<int>> UpdateUploadAsync(UpdateAdvertisementContentCommand updateAdvertisementCommand,
        CancellationToken cancellationToken);
    Task<IResult> AddCountAsync(AddCountAdvertisementCommand command, CancellationToken cancellationToken);
}