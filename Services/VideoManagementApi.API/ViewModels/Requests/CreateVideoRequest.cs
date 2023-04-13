using VideoManagementApi.Application.Features.SeoFeatures.Commands;
using VideoManagementApi.Application.Features.VideoAndCategoryFeatures.Commands;

namespace VideoManagementApi.API.ViewModels.Requests;

public class CreateVideoRequest
{
    public IFormFile File { get; set; }
}