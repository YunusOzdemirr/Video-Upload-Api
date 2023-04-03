using AutoMapper;
using VideoManagementApi.Application.Features.AdvertisementFeatures.Commands;
using VideoManagementApi.Application.Features.AdvertisementFeatures.Queries;
using VideoManagementApi.Application.Interfaces.Services;
using VideoManagementApi.Domain.Common;
using VideoManagementApi.Domain.Entities;

namespace VideoManagementApi.Infrastructure.Services;

public class AdvertisementService : IAdvertisementService
{
    private readonly IAdvertisementRepository _repository;
    private readonly IMapper _mapper;

    public AdvertisementService(IAdvertisementRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<IResult> CreateAsync(CreateAdvertisementCommand createAdvertisementCommand,
        CancellationToken cancellationToken)
    {
        var advertisement = _mapper.Map<Advertisement>(createAdvertisementCommand);
        await _repository.AddAsync(advertisement, cancellationToken);
        return await Result.SuccessAsync();
    }

    public async Task<IResult> UpdateAsync(UpdateAdvertisementCommand updateAdvertisementCommand,
        CancellationToken cancellationToken)
    {
        var oldAdvertisement = await _repository.GetByIdAsync(updateAdvertisementCommand.Id, cancellationToken);
        if (oldAdvertisement == null)
            return await Result.FailAsync();
        var newAdvertisement =
            _mapper.Map<UpdateAdvertisementCommand, Advertisement>(updateAdvertisementCommand, oldAdvertisement);
        await _repository.UpdateAsync(newAdvertisement, cancellationToken);
        return await Result.SuccessAsync();
    }

    public async Task<IResult<List<Advertisement>>> GetAllAsync(GetAllAdvertisementsQuery getAdvertisementsQuery,
        CancellationToken cancellationToken)
    {
        var advertisements = await _repository.GetAllAsync(cancellationToken: cancellationToken);
        return await Result<List<Advertisement>>.SuccessAsync(advertisements);
    }
}