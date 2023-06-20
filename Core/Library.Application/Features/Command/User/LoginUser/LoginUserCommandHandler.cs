using Library.Application.DTOs;
using Library.Application.Helpers;
using Library.Application.Repositories;
using Library.Application.Services;
using MediatR;

namespace Library.Application.Features.Command.User.LoginUser;

public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, ResponseDto<TokenDto>>
{
    private readonly IUserRepository _userRepository;
    private readonly IAuthService _authService;

    public LoginUserCommandHandler(IUserRepository userRepository, IAuthService authService)
    {
        _userRepository = userRepository;
        _authService = authService;
    }


    public async Task<ResponseDto<TokenDto>> Handle(LoginUserCommand request, CancellationToken cancellationToken)
    {
        var currentUser = await _userRepository.GetByEmail(request.Email);

        if (!HashingHelper.VerifyPasswordHash(request.Password, currentUser.PasswordHash, currentUser.PasswordSalt))
            throw new Exception("Wrong Email or Password");

        return ResponseDto<TokenDto>.Success(_authService.CreateToken(currentUser), 200);
    }
}