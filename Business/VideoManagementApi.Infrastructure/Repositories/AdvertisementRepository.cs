using VideoManagementApi.Domain.Entities;
using VideoManagementApi.Infrastructure.Context;

namespace VideoManagementApi.Infrastructure.Repositories;

public class AdvertisementRepository : GenericRepository<Advertisement>, IAdvertisementRepository
{
    public AdvertisementRepository(VideoContext context) : base(context)
    {
    }
}