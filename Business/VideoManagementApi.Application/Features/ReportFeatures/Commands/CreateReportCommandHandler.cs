using AutoMapper;
using VideoManagementApi.Domain.Entities;

namespace VideoManagementApi.Application.Features.ReportFeatures.Commands;

public class CreateReportCommandHandler : IRequestHandler<CreateReportCommand, IResult>
{
    private readonly IReportRepository _reportRepository;
    private readonly IMapper _mapper;
    public CreateReportCommandHandler(IReportRepository reportRepository, IMapper mapper)
    {
        _reportRepository = reportRepository;
        _mapper = mapper;
    }

    public async Task<IResult> Handle(CreateReportCommand request, CancellationToken cancellationToken)
    {
        var report = _mapper.Map<Report>(request);
        var result = await _reportRepository.AddAsync(report,cancellationToken);
        if (result)
            return await Result.SuccessAsync();
        return await Result.FailAsync();
    }
}