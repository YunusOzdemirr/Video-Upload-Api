using VideoManagementApi.Domain.Entities;
using VideoManagementApi.Infrastructure.Context;

namespace VideoManagementApi.Infrastructure.Repositories;


public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
{
    public CategoryRepository(VideoContext context) : base(context)
    {
    }
}