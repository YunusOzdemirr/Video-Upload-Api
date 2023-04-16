using Microsoft.AspNetCore.Http;

namespace VideoManagementApi.Application.Features.CategoryFeatures.Commands;

public class CreateCategoryCommand : IRequest<IResult>
{
    public string Name { get; set; }
    public IFormFile File { get; set; }
}