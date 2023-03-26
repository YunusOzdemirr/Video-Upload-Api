using VideoManagementApi.Domain.Entities;
using VideoManagementApi.Infrastructure.Context;

namespace VideoManagementApi.Infrastructure.Repositories;

public class VideoRepository : GenericRepository<Video>, IVideoRepository
{
    public VideoRepository(VideoContext context) : base(context)
    {
    }
}