using VideoManagementApi.DataAccess.EntityFramework;
using VideoManagementApi.DataAccess.Repositories.Abstract;
using VideoManagementApi.Models;

namespace VideoManagementApi.DataAccess.Repositories;

public class VideoRepository : GenericRepository<Video>, IVideoRepository
{
    public VideoRepository(VideoContext context) : base(context)
    {
    }
}