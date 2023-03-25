using MediatR;
using IResult = VideoManagementApi.Utilities.IResult;

namespace VideoManagementApi.Features.Commands.VideoCommands;

public class UpdateVideoCommand : IRequest<IResult>
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public IFormFile File { get; set; }
}