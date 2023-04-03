using AutoMapper;
using VideoManagementApi.Application.Features.CategoryFeatures.Commands;
using VideoManagementApi.Domain.Entities;

namespace VideoManagementApi.Infrastructure.Mappings;

public class CategoryProfile : Profile
{
    public CategoryProfile()
    {
        CreateMap<CreateCategoryCommand, Category>();
        CreateMap<UpdateCategoryCommand, Category>();
    }
}