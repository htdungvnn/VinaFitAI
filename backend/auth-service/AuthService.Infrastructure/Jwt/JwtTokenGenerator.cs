using AuthService.Application.Interfaces;
using AuthService.Domain.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Http;

namespace AuthService.Infrastructure.Jwt;

public class JwtTokenGenerator : ITokenService
{
    private readonly IConfiguration _cfg;

    public JwtTokenGenerator(IConfiguration cfg)
    {
        _cfg = cfg;
    }

    public TokenResult GenerateTokens(User user)
    {
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_cfg["JWT_KEY"]));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var claims = new List<Claim>
        {
            new Claim("user_id", user.Id.ToString()),
            new Claim("phone", user.Phone ?? "")
        };

        var jwt = new JwtSecurityToken(
            issuer: _cfg["JWT_ISSUER"],
            audience: _cfg["JWT_AUDIENCE"],
            claims: claims,
            expires: DateTime.UtcNow.AddHours(2),
            signingCredentials: creds
        );

        return new TokenResult
        {
            AccessToken = new JwtSecurityTokenHandler().WriteToken(jwt),
            RefreshToken = Guid.NewGuid().ToString()
        };
    }

    public Task<TokenResult> RefreshTokenAsync(string refreshToken)
    {
        // Later: validate refresh token, find user, generate new tokens
        return Task.FromResult(new TokenResult
        {
            AccessToken = "new-access-token",
            RefreshToken = Guid.NewGuid().ToString()
        });
    }

    /// <summary>
    /// Extract user info from HttpContext.User (JWT ClaimsPrincipal)
    /// </summary>
    public User? GetUserFromContext(HttpContext ctx)
    {
        var principal = ctx.User;

        if (principal == null || !principal.Identity?.IsAuthenticated == true)
            return null;

        var userId = principal.FindFirst("user_id")?.Value;
        var phone = principal.FindFirst("phone")?.Value;

        if (userId == null)
            return null;

        return new User
        {
            Id = Guid.Parse(userId),
            Phone = phone
        };
    }
}