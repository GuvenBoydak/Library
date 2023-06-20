namespace Library.Application.DTOs;

public class TokenDto
{
    public DateTime Expiration { get; set; }
    public string AccessToken { get; set; }
}