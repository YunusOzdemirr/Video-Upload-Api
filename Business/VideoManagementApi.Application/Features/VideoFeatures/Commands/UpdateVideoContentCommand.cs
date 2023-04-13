using Microsoft.AspNetCore.Http;

namespace VideoManagementApi.Application.Features.VideoFeatures.Commands;

public class UpdateVideoContentCommand : IRequest<IResult<int>>
{
    public int Id { get; set; }
    public IFormFile File { get; set; }
}