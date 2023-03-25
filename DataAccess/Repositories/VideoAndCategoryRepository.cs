using VideoManagementApi.DataAccess.EntityFramework;
using VideoManagementApi.DataAccess.Repositories.Abstract;
using VideoManagementApi.Models;

namespace VideoManagementApi.DataAccess.Repositories;

public class VideoAndCategoryRepository : GenericRepository<VideoAndCategory>, IVideoAndCategoryRepository
{
    public VideoAndCategoryRepository(VideoContext context) : base(context)
    {
    }
}