using VideoManagementApi.Domain.Entities;
using VideoManagementApi.Infrastructure.Context;

namespace VideoManagementApi.Infrastructure.Repositories;


public class CommentRepository : GenericRepository<Comment>, ICommentRepository
{
    public CommentRepository(VideoContext context) : base(context)
    {
    }
}