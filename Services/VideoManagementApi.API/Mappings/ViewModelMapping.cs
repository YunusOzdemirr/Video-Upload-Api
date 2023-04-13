using AutoMapper;
using VideoManagementApi.API.ViewModels.Requests;
using VideoManagementApi.Application.Features.AdvertisementFeatures.Commands;
using VideoManagementApi.Application.Features.CategoryFeatures.Commands;
using VideoManagementApi.Application.Features.CommentFeatures.Commands;
using VideoManagementApi.Application.Features.LikeFeatures.Commands;
using VideoManagementApi.Application.Features.SeoFeatures.Commands;
using VideoManagementApi.Application.Features.VideoFeatures.Commands;

namespace VideoManagementApi.API.Mappings;

public class ViewModelMapping : Profile
{
    public ViewModelMapping()
    {
        CreateAdvertisementMapping();
        CreateCategoryMapping();
        CreateCommentMapping();
        CreateLikeMapping();
        CreateSeoMapping();
        CreateVideoMapping();
    }

    public void CreateAdvertisementMapping()
    {
        CreateMap<CreateAdvertisementRequest, CreateAdvertisementCommand>();
        CreateMap<UpdateAdvertisementRequest, UpdateAdvertisementCommand>();
    }

    public void CreateCategoryMapping()
    {
        CreateMap<CreateCategoryRequest, CreateCategoryCommand>();
        CreateMap<UpdateCategoryRequest, UpdateCategoryCommand>();
    }

    public void CreateCommentMapping()
    {
        CreateMap<CreateCommentRequest, CreateCommentCommand>();
    }

    public void CreateLikeMapping()
    {
        CreateMap<CreateOrUpdateLikeRequest, CreateOrUpdateLikeCommand>();
    }

    public void CreateSeoMapping()
    {
        CreateMap<CreateSeoRequest, CreateSeoCommand>();
        CreateMap<UpdateSeoRequest, UpdateSeoCommand>();
    }

    public void CreateVideoMapping()
    {
        CreateMap<CreateVideoRequest, CreateVideoCommand>();
        CreateMap<UpdateVideoRequest, UpdateVideoCommand>();
    }
}