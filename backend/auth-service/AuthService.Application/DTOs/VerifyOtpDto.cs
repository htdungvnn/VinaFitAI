namespace AuthService.Application.DTOs;

public class VerifyOtpDto
{
    public string Phone { get; set; }
    public string Code { get; set; }
}