namespace AuthService.Application.Interfaces;

public interface IFirebaseOtpProvider
{
    Task SendOtp(string phone);
    Task<bool> VerifyOtp(string phone, string code);
}