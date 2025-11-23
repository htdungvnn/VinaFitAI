using AuthService.Application.DTOs;
using AuthService.Application.Interfaces;
using AuthService.Domain.Entities;

namespace AuthService.Application.Services;

public class AuthService : IAuthService
{
    private readonly IFirebaseOtpProvider _otp;
    private readonly IUserRepository _users;
    private readonly ITokenService _tokens;

    public AuthService(IFirebaseOtpProvider otp, IUserRepository users, ITokenService tokens)
    {
        _otp = otp;
        _users = users;
        _tokens = tokens;
    }

    public async Task<ResultMessage> RequestOtpAsync(RequestOtpDto dto)
    {
        await _otp.SendOtp(dto.Phone);
        return ResultMessage.Ok("OTP sent");
    }

    public async Task<AuthResult> VerifyOtpAsync(VerifyOtpDto dto)
    {
        var valid = await _otp.VerifyOtp(dto.Phone, dto.Code);
        if (!valid) throw new Exception("OTP invalid");

        var user = await _users.GetOrCreateAsync(dto.Phone);

        var token = _tokens.GenerateTokens(user);

        return new AuthResult(user.Id, token);
    }
}