using Library.Application.DTOs;
using Library.Application.DTOs.User;
using MediatR;

namespace Library.Application.Features.Command.User.RegisterUser;

public record RegisterUserCommand
(string FirstName, string LastName, string Email, string PhoneNumber,
    string Password) : IRequest<ResponseDto<UserDto>>;