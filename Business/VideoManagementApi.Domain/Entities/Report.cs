using VideoManagementApi.Domain.Common;
using VideoManagementApi.Domain.Enums;

namespace VideoManagementApi.Domain.Entities;

public class Report : BaseEntity
{
    public string Title { get; set; }
    public string Description { get; set; }
    public string IpAddress { get; set; }
    public string VideoUrl { get; set; }
    public ReportType ReportType { get; set; }
}