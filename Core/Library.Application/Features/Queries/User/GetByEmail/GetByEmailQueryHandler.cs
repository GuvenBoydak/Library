using AutoMapper;
using Library.Application.DTOs;
using Library.Application.DTOs.User;
using Library.Application.Repositories;
using MediatR;

namespace Library.Application.Features.Queries.User.GetByEmail;

public class GetByEmailQueryHandler : IRequestHandler<GetByEmailQuery, ResponseDto<UserDto>>
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public GetByEmailQueryHandler(IUserRepository userRepository, IMapper mapper)
    {
        _mapper = mapper;
        _userRepository = userRepository;
    }

    public async Task<ResponseDto<UserDto>> Handle(GetByEmailQuery request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByEmail(request.Email);

        return ResponseDto<UserDto>.Success(_mapper.Map<Domain.Entities.User, UserDto>(user), 200);
    }
}