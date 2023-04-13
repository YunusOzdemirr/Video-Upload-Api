using VideoManagementApi.Application.Features.SeoFeatures.Commands;
using VideoManagementApi.Application.Features.VideoAndCategoryFeatures.Commands;

namespace VideoManagementApi.API.ViewModels.Requests;

public class UpdateVideoRequest
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public List<CreateSeoCommand>? Seos { get; set; }
    public List<CreateVideoAndCategoryCommand>? VideoAndCategories { get; set; }
}