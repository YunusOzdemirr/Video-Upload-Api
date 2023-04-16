using AutoMapper;
using VideoManagementApi.Application.Features.ReportFeatures;
using VideoManagementApi.Application.Features.ReportFeatures.Commands;
using VideoManagementApi.Domain.Entities;

namespace VideoManagementApi.Application.Mappings;

public class ReportMapping : Profile
{
    public ReportMapping()
    {
        CreateMap<CreateReportCommand, Report>();
    }
}