namespace VideoManagementApi.Application.Features.VideoFeatures.Commands;

public class ChangeStatusVideoCommand : IRequest<IResult>
{
    public int Id { get; set; }
    public bool IsActive { get; set; }
}