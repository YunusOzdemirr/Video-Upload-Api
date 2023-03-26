namespace VideoManagementApi.Application.Features.VideoAndCategoryFeatures.Commands;

public class DeleteVideoAndCategoryCommand : IRequest<IResult>
{
    public int VideoId { get; set; }
    public int CategoryId { get; set; }
}