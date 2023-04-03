using AutoMapper;
using VideoManagementApi.Application.Features.SeoFeatures.Commands;
using VideoManagementApi.Domain.Entities;

namespace VideoManagementApi.Infrastructure.Mappings;

public class SeoProfile : Profile
{
    public SeoProfile()
    {
        CreateMap<CreateSeoCommand, Seo>();
        CreateMap<UpdateSeoCommand, Seo>();
    }
}