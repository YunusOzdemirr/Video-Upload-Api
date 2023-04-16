using VideoManagementApi.Domain.Entities;

namespace VideoManagementApi.Application.Features.ReportFeatures.Queries;

public class GetReportsQueryHandler : IRequestHandler<GetReportsQuery, IResult<List<Report>>>
{
    private readonly IReportRepository _repository;

    public GetReportsQueryHandler(IReportRepository repository)
    {
        _repository = repository;
    }

    public async Task<IResult<List<Report>>> Handle(GetReportsQuery request, CancellationToken cancellationToken)
    {
        var result = await _repository.GetAllAsync(cancellationToken:cancellationToken);
        if (result.Any())
            return await Result<List<Report>>.SuccessAsync(result);
        return await Result<List<Report>>.FailAsync();
    }
}