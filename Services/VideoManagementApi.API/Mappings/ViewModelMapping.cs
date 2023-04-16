using AutoMapper;
using VideoManagementApi.API.ViewModels.Requests;
using VideoManagementApi.Application.Features.AdvertisementFeatures.Commands;
using VideoManagementApi.Application.Features.CategoryFeatures.Commands;
using VideoManagementApi.Application.Features.CommentFeatures.Commands;
using VideoManagementApi.Application.Features.LikeFeatures.Commands;
using VideoManagementApi.Application.Features.SeoFeatures.Commands;
using VideoManagementApi.Application.Features.VideoAndCategoryFeatures.Commands;
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
        CreateVideoAndCategoryMapping();
    }

    public void CreateAdvertisementMapping()
    {
        CreateMap<CreateAdvertisementRequest, CreateAdvertisementCommand>();
        CreateMap<UpdateAdvertisementRequest, UpdateAdvertisementCommand>();
    }

    public void CreateCategoryMapping()
    {
        CreateMap<CreateCategoryRequest, CreateCategoryCommand>();
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
        CreateMap<CreateSeoInUpdateVideoRequest, CreateSeoCommand>();
    }

    public void CreateVideoMapping()
    {
        CreateMap<CreateVideoRequest, CreateVideoCommand>();
        CreateMap<UpdateVideoRequest, UpdateVideoCommand>();
    }

    public void CreateVideoAndCategoryMapping()
    {
        CreateMap<CreateVideoAndCategoryInVideoUpdateRequest, CreateVideoAndCategoryCommand>();
    }
}