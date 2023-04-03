using AutoMapper;
using VideoManagementApi.Application.Features.AdvertisementFeatures.Commands;
using VideoManagementApi.Domain.Entities;

namespace VideoManagementApi.Infrastructure.Mappings;

public class AdvertisementProfile : Profile
{
    public AdvertisementProfile()
    {
        CreateMap<CreateAdvertisementCommand, Advertisement>();
        CreateMap<UpdateAdvertisementCommand, Advertisement>();
    }
}