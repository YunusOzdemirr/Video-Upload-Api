using Microsoft.AspNetCore.Http;
using VideoManagementApi.Application.Features.SeoFeatures.Commands;
using VideoManagementApi.Application.Features.VideoAndCategoryFeatures.Commands;
using VideoManagementApi.Domain.Entities;

namespace VideoManagementApi.Application.Features.VideoFeatures.Commands;

public class CreateVideoCommand : IRequest<IResult>
{
    public string Title { get; set; }
    public string Description { get; set; }
    public IFormFile? File { get; set; }
    public List<CreateSeoCommand>? Seos { get; set; }
    public List<CreateVideoAndCategoryCommand>? VideoAndCategories { get; set; }
}