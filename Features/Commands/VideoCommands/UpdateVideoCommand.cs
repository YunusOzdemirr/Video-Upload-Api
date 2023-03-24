using AutoMapper;
using MediatR;
using VideoManagementApi.Dtos.VideoDtos;
using VideoManagementApi.Services.Abstract;
using IResult = VideoManagementApi.Utilities.IResult;

namespace VideoManagementApi.Features.Commands.VideoCommands;

public class UpdateVideoCommand : IRequest<IResult>
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public IFormFile File { get; set; }
}

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
        var model = _mapper.Map<VideoUpdateDto>(request);
        return await _uploadService.UpdateAsync(model);
    }
}