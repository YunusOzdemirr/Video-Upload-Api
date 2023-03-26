using VideoManagementApi.Domain.Entities;
using VideoManagementApi.Infrastructure.Context;

namespace VideoManagementApi.Infrastructure.Repositories;

public class SeoRepository : GenericRepository<Seo>, ISeoRepository
{
    public SeoRepository(VideoContext context) : base(context)
    {
    }
}