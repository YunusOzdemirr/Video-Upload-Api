using Microsoft.AspNetCore.Http;

namespace VideoManagementApi.Application.Features.CategoryFeatures.Commands;

public class UpdateCategoryCommand : IRequest<IResult>
{
    public int Id { get; set; }
    public string Name { get; set; }
    public IFormFile File { get; set; }
}