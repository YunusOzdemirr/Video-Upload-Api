using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoManagementApi.Domain.Entities;
using VideoManagementApi.Infrastructure.Context;

namespace VideoManagementApi.Infrastructure.Repositories
{
    public class UserRepository : GenericRepository<User> , IUserRepository 
    {
        public UserRepository(VideoContext context):base(context) 
        {
        }
    }
}
