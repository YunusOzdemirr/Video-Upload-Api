using AutoMapper;
using VideoManagementApi.Application.Features.LikeFeatures.Commands;
using VideoManagementApi.Domain.Entities;

namespace VideoManagementApi.Infrastructure.Mappings;

public class LikeProfile : Profile
{
    public LikeProfile()
    {
        CreateMap<CreateOrUpdateLikeCommand, Like>();
    }
}