using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Library.Application.DTOs;
using Library.Application.Services;
using Library.Domain.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Library.Persistance.Services;

public class AuthService:IAuthService
{
    private readonly IConfiguration _configuration;

    public AuthService(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    
    public TokenDto CreateToken(User user)
    {
        var tokenExpiration = DateTime.Now.AddMinutes(20);

        var securityKey =
            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("SecurityKey").Value));

        var signingCredentials =
            new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512Signature);

        var jwt = new JwtSecurityToken(expires: tokenExpiration, signingCredentials: signingCredentials);

        string token = new JwtSecurityTokenHandler().WriteToken(jwt);

        return new TokenDto() { AccessToken = token, Expiration = tokenExpiration };
    }
}