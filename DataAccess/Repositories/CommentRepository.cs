using VideoManagementApi.DataAccess.EntityFramework;
using VideoManagementApi.DataAccess.Repositories.Abstract;
using VideoManagementApi.Models;

namespace VideoManagementApi.DataAccess.Repositories;

public class CommentRepository : GenericRepository<Comment>, ICommentRepository
{
    public CommentRepository(VideoContext context) : base(context)
    {
    }
}