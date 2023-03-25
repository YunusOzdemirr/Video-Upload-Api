using VideoManagementApi.DataAccess.EntityFramework;
using VideoManagementApi.DataAccess.Repositories.Abstract;
using VideoManagementApi.Models;

namespace VideoManagementApi.DataAccess.Repositories;

public class SeoRepository : GenericRepository<Seo>, ISeoRepository
{
    public SeoRepository(VideoContext context) : base(context)
    {
    }
}