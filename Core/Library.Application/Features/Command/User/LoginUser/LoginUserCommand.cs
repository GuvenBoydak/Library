using Library.Application.DTOs;
using Library.Application.Exceptions;
using MediatR;

namespace Library.Application.Features.Command.User.LoginUser;

public record LoginUserCommand(string Email, string Password) : IRequest<ResponseDto<TokenDto>>;