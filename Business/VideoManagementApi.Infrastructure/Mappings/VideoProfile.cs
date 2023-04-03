using AutoMapper;
using VideoManagementApi.Application.Features.VideoFeatures.Commands;
using VideoManagementApi.Domain.Entities;

namespace VideoManagementApi.Infrastructure.Mappings;

public class VideoProfile : Profile
{
    public VideoProfile()
    {
        CreateMap<CreateVideoCommand, Video>();
        CreateMap<UpdateVideoCommand, Video>();
    }
}