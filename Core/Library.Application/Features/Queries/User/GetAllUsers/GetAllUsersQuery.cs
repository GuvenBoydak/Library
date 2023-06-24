using AutoMapper;
using Library.Application.DTOs;
using Library.Application.DTOs.User;
using Library.Application.Repositories;
using MediatR;

namespace Library.Application.Features.Queries.User.GetAllUsers
{
    public record GetAllUsersQuery : IRequest<ResponseDto<List<UserListDto>>>;
    public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, ResponseDto<List<UserListDto>>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public GetAllUsersQueryHandler(IMapper mapper, IUserRepository userRepository)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public async Task<ResponseDto<List<UserListDto>>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            var users = await _userRepository.GetAllAsync();

            return ResponseDto<List<UserListDto>>.Success(_mapper.Map<List<Domain.Entities.User>, List<UserListDto>>(users), 200);
        }
    }

}
