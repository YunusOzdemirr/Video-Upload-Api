using AutoMapper;
using MediatR;
using VideoManagementApi.Dtos.VideoDtos;
using VideoManagementApi.Services.Abstract;
using IResult = VideoManagementApi.Utilities.IResult;

namespace VideoManagementApi.Features.Commands.VideoCommands;

public class UpdateVideoCommandHandler : IRequestHandler<UpdateVideoCommand, IResult>
{
    private IUploadService _uploadService;
    private IMapper _mapper;

    public UpdateVideoCommandHandler(IUploadService uploadService, IMapper mapper)
    {
        _uploadService = uploadService;
        _mapper = mapper;
    }

    public async Task<IResult> Handle(UpdateVideoCommand request, CancellationToken cancellationToken)
    {
        return await _uploadService.UpdateAsync(request);
    }
}