using AutoMapper;
using MediatR;
using VideoManagementApi.Dtos.VideoDtos;
using VideoManagementApi.Models;
using VideoManagementApi.Utilities;
using IResult = VideoManagementApi.Utilities.IResult;

namespace VideoManagementApi.Features.Queries.VideoQueries;

public class GetVideosQuery : IRequest<IResult<List<Video>>>
{
    public bool? IsActive { get; set; }
}