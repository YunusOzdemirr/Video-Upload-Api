using VideoManagementApi.Domain.Entities;

namespace VideoManagementApi.Application.Features.ReportFeatures.Queries;

public class GetReportsQuery : IRequest<IResult<List<Report>>>
{
}