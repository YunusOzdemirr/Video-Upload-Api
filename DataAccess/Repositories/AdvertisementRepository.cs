using VideoManagementApi.DataAccess.EntityFramework;
using VideoManagementApi.DataAccess.Repositories.Abstract;
using VideoManagementApi.Models;

namespace VideoManagementApi.DataAccess.Repositories;

public class AdvertisementRepository : GenericRepository<Advertisement>, IAdvertisementRepository
{
    public AdvertisementRepository(VideoContext context) : base(context)
    {
    }
}