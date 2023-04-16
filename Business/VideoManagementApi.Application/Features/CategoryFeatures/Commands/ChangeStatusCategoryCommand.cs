namespace VideoManagementApi.Application.Features.CategoryFeatures.Commands;

public class ChangeStatusCategoryCommand : IRequest<IResult>
{
    public int Id { get; set; }
    public bool IsActive { get; set; }
}