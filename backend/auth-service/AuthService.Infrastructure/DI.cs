using AuthService.Application.Interfaces;
using AuthService.Application.Services;
using AuthService.Infrastructure.Firebase;
using AuthService.Infrastructure.Jwt;
using AuthService.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AuthService.Infrastructure.DI;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IAuthService, AuthService.Application.Services.AuthService>();
        return services;
    }

    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration cfg)
    {
        services.AddDbContext<AuthDbContext>(o =>
            o.UseNpgsql(cfg["DB_CONNECTION"]));

        services.AddHttpClient<IFirebaseOtpProvider, FirebaseOtpProvider>();
        services.AddScoped<ITokenService, JwtTokenGenerator>();
        services.AddScoped<IUserRepository, UserRepository>();

        return services;
    }
}