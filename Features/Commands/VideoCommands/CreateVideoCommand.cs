using MediatR;
using VideoManagementApi.Dtos.CategoryDtos;
using VideoManagementApi.Dtos.SeoDtos;
using VideoManagementApi.Models;
using IResult = VideoManagementApi.Utilities.IResult;

namespace VideoManagementApi.Features.Commands.VideoCommands;

public abstract class CreateVideoCommand : IRequest<IResult>
{
    public string Title { get; set; }
    public string Description { get; set; }
    public IFormFile File { get; set; }
    public ICollection<SeoAddDto> Seos { get; set; }
    public ICollection<Category> VideoAndCategories { get; set; }
}