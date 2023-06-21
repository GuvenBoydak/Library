using Library.Application.DTOs;
using Library.Application.DTOs.User;
using MediatR;

namespace Library.Application.Features.Queries.User.GetByEmail;

public record GetByEmailQuery(string Email) : IRequest<ResponseDto<UserDto>>;