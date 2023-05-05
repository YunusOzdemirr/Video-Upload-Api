using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoManagementApi.Application.Features.UserFeatures
{
    public class CreateUserCommand : IRequest<IResult>
    {
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string Password { get; set; }
    }
}
