using AutoMapper;
using VideoManagementApi.Domain.Entities;

namespace VideoManagementApi.Application.Features.UserFeatures
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, IResult>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public CreateUserCommandHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<IResult> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = _mapper.Map<User>(request);
            var result = await _userRepository.AddAsync(user, cancellationToken);
            return await Result.SuccessAsync();
        }
    }
}
