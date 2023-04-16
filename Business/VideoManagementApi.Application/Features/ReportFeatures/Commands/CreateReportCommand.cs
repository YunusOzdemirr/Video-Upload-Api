using VideoManagementApi.Domain.Enums;

namespace VideoManagementApi.Application.Features.ReportFeatures.Commands;

public class CreateReportCommand : IRequest<IResult>
{
    public string Title { get; set; }
    public string Description { get; set; }
    public string IpAddress { get; set; }
    public ReportType ReportType { get; set; }
}