using VideoManagementApi.Domain.Enums;

namespace VideoManagementApi.Application.Features.VideoFeatures.Commands;

public class AddCountVideoCommand : IRequest<IResult>
{
    public int Id { get; set; }
}