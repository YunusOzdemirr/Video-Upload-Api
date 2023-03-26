namespace VideoManagementApi.Application.Features.CategoryFeatures.Commands;

public class CreateCategoryCommand : IRequest<IResult>
{
    public string Name { get; set; }
    public string FilePath { get; set; }
    public string FileName { get; set; }
}