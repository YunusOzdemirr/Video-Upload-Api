using VideoManagementApi.Domain.Entities;

namespace VideoManagementApi.Application.Features.UserFeatures
{
    public class GetUserByIdQuery : IRequest<IResult<User>>
    {
        public int Id { get; set; }
    }
}
