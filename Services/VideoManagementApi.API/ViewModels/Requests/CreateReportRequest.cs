using VideoManagementApi.Domain.Enums;

namespace VideoManagementApi.API.ViewModels.Requests;

public class CreateReportRequest
{
    public string Title { get; set; }
    public string Description { get; set; }
    public ReportType ReportType { get; set; }
}