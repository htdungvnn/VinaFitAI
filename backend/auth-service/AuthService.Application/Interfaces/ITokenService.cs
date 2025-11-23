
using AuthService.Domain.Entities;
using Microsoft.AspNetCore.Http;

namespace AuthService.Application.Interfaces;

public interface ITokenService
{
    TokenResult GenerateTokens(User user);
    Task<TokenResult> RefreshTokenAsync(string refreshToken);
    User? GetUserFromContext(HttpContext ctx);
}