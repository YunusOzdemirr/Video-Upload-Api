using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using VideoManagementApi.Domain.Common;

namespace VideoManagementApi.Domain.Entities
{
    public class User : BaseEntity
    {
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string Password { get; set; }
    }
}
