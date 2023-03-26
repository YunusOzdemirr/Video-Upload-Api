using VideoManagementApi.Domain.Entities;
using VideoManagementApi.Infrastructure.Context;

namespace VideoManagementApi.Infrastructure.Repositories;

public class LikeRepository : GenericRepository<Like>, ILikeRepository
{
    public LikeRepository(VideoContext context) : base(context)
    {
    }
}