using AutoMapper;
using VideoManagementApi.Application.Features.CommentFeatures.Commands;
using VideoManagementApi.Domain.Entities;

namespace VideoManagementApi.Infrastructure.Mappings;

public class CommentProfile : Profile
{
    public CommentProfile()
    {
        CreateMap<CreateCommentCommand, Comment>();
        CreateMap<ApproveCommentCommand, Comment>();
    }
}