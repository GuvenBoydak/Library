using Library.Application.DTOs;
using Library.Domain.Entities;

namespace Library.Application.Services;

public interface IAuthService
{
    TokenDto CreateToken(User user);
}