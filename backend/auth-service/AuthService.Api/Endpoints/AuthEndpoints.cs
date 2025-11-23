using AuthService.Application.DTOs;
using AuthService.Application.Interfaces;

public static class AuthEndpoints
{
    public static void Map(WebApplication app)
    {
        var group = app.MapGroup("/auth");

        group.MapPost("/request-otp", async (RequestOtpDto dto, IAuthService auth) =>
        {
            var result = await auth.RequestOtpAsync(dto);
            return Results.Ok(result);
        });

        group.MapPost("/verify-otp", async (VerifyOtpDto dto, IAuthService auth) =>
        {
            var result = await auth.VerifyOtpAsync(dto);
            return Results.Ok(result);
        });

        group.MapGet("/me", (HttpContext ctx, ITokenService tokens) =>
        {
            var user = tokens.GetUserFromContext(ctx);
            return Results.Ok(user);
        });
    }
}