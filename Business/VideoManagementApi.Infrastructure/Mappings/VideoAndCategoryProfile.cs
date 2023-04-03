using AutoMapper;
using VideoManagementApi.Application.Features.VideoAndCategoryFeatures.Commands;
using VideoManagementApi.Domain.Entities;

namespace VideoManagementApi.Infrastructure.Mappings;

public class VideoAndCategoryProfile : Profile
{
    public VideoAndCategoryProfile()
    {
        CreateMap<CreateVideoAndCategoryCommand, VideoAndCategory>();
    }
}