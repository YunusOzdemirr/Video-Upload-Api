namespace VideoManagementApi.Application.Features.CategoryFeatures.Commands;

public class DeleteCategoryCommand : IRequest<IResult>
{
    public int Id { get; set; }
}