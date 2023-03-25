using VideoManagementApi.DataAccess.EntityFramework;
using VideoManagementApi.DataAccess.Repositories.Abstract;
using VideoManagementApi.Models;

namespace VideoManagementApi.DataAccess.Repositories;

public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
{
    public CategoryRepository(VideoContext context) : base(context)
    {
    }
}