using AutoMapper;
using VideoManagementApi.Application.Features.AdvertisementFeatures.Commands;
using VideoManagementApi.Application.Features.AdvertisementFeatures.Queries;
using VideoManagementApi.Application.Interfaces.Services;
using VideoManagementApi.Domain.Common;
using VideoManagementApi.Domain.Entities;
using VideoManagementApi.Domain.Enums;
using VideoManagementApi.Infrastructure.Utilities;

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

    public async Task<IResult<int>> CreateAsync(CreateAdvertisementCommand createAdvertisementCommand,
        CancellationToken cancellationToken)
    {
        var advertisement = _mapper.Map<Advertisement>(createAdvertisementCommand);
        var result = await FileUpload.UploadAlternative(createAdvertisementCommand.File, "Advertisements", "");
        if (!result.Succeeded)
            return await Result<int>.FailAsync();
        advertisement.FileName = result.Message;
        advertisement.FilePath = result.Data as string;
        await _repository.AddAsync(advertisement, cancellationToken);
        return await Result<int>.SuccessAsync(advertisement.Id);
    }
    
    public async Task<IResult<int>> UpdateUploadAsync(UpdateAdvertisementContentCommand updateAdvertisementCommand,
        CancellationToken cancellationToken)
    {
        var advertisement = await _repository.GetByIdAsync(updateAdvertisementCommand.Id, cancellationToken);
        if (advertisement == null)
        {
            var advertisementCommand = new CreateAdvertisementCommand()
            {
                Description = "Upload Başarılı 2. Adım Bekleniyor || Update işlemi içerisinde create edilen reklam",
                File = updateAdvertisementCommand.File,
            };
            var advertisementId = await CreateAsync(advertisementCommand, cancellationToken);
            if (advertisementId.Succeeded)
                return await Result<int>.SuccessAsync(data: advertisementId.Data as int? ?? default(int));
            return await Result<int>.FailAsync(default(int));
        }

        var result = await FileUpload.UploadAlternative(updateAdvertisementCommand.File, "Advertisements", "");
        if (!result.Succeeded)
            return await Result<int>.FailAsync();
        await FileUpload.Delete(advertisement.FilePath);
        advertisement.FileName = result.Message;
        advertisement.FilePath = result.Data as string;
        advertisement.IsActive = true;
        await _repository.UpdateAsync(advertisement, cancellationToken);
        return await Result<int>.SuccessAsync(advertisement.Id);
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

    public async Task<IResult> AddCountAsync(AddCountAdvertisementCommand command, CancellationToken cancellationToken)
    {
        var advertisement = await _repository.GetByIdAsync(command.Id, cancellationToken);
        if (advertisement == null)
            return await Result.FailAsync();

        if (command.CountType == CountType.Click)
            advertisement.ClickCount++;
        advertisement.WatchCount++;
        await _repository.UpdateAsync(advertisement, cancellationToken);
        return await Result.SuccessAsync();
    }
}