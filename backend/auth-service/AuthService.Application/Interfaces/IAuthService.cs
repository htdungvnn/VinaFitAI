
using AuthService.Application.DTOs;

namespace AuthService.Application.Interfaces;

public interface IAuthService
{
    Task<ResultMessage> RequestOtpAsync(RequestOtpDto dto);
    Task<AuthResult> VerifyOtpAsync(VerifyOtpDto dto);
}