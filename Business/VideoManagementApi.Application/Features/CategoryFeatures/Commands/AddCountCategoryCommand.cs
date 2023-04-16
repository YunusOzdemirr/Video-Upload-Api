namespace VideoManagementApi.Application.Features.CategoryFeatures.Commands;

public class AddCountCategoryCommand : IRequest<IResult>
{
    public int Id { get; set; }
}