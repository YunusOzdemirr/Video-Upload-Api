using AutoMapper;
using MediatR;
using VideoManagementApi.Dtos.VideoDtos;
using VideoManagementApi.Services.Abstract;
using IResult = VideoManagementApi.Utilities.IResult;

namespace VideoManagementApi.Features.Commands.VideoCommands;

public class CreateVideoCommandHandler : IRequestHandler<CreateVideoCommand, IResult>
{
    private IUploadService _uploadService;
    private IMapper _mapper;

    public CreateVideoCommandHandler(IUploadService uploadService, IMapper mapper)
    {
        _uploadService = uploadService;
        _mapper = mapper;
    }

    public async Task<IResult> Handle(CreateVideoCommand request, CancellationToken cancellationToken)
    {
        var models = _mapper.Map<VideoAddDto>(request);
        return await _uploadService.UploadAsync(models);
    }
}