
using AuthService.Application.Interfaces;

public static class TokenEndpoints
{
    public static void Map(WebApplication app)
    {
        var group = app.MapGroup("/auth");

        group.MapPost("/refresh-token", async (string refreshToken, ITokenService service) =>
        {
            var result = await service.RefreshTokenAsync(refreshToken);
            return Results.Ok(result);
        });
    }
}