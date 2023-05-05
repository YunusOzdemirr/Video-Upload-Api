using VideoManagementApi.Domain.Entities;

namespace VideoManagementApi.Application.Features.UserFeatures
{
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, IResult<User>>
    {
        private readonly IUserRepository _userRepository;

        public GetUserByIdQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IResult<User>> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdAsync(request.Id, cancellationToken);
            return await Result<User>.SuccessAsync(user);
        }
    }
}
