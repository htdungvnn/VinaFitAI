using AuthService.Domain.Entities;

namespace AuthService.Application.DTOs;

public class AuthResult
{
    public Guid UserId { get; set; }
    public TokenResult Token { get; set; }

    public AuthResult(Guid id, TokenResult token)
    {
        UserId = id;
        Token = token;
    }
}