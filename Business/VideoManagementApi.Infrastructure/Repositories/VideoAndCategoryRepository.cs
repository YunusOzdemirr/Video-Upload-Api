using VideoManagementApi.Domain.Entities;
using VideoManagementApi.Infrastructure.Context;

namespace VideoManagementApi.Infrastructure.Repositories;

public class VideoAndCategoryRepository : GenericRepository<VideoAndCategory>, IVideoAndCategoryRepository
{
    public VideoAndCategoryRepository(VideoContext context) : base(context)
    {
    }
}