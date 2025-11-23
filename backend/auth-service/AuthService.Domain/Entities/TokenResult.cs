namespace AuthService.Domain.Entities;

public class TokenResult
{
    public string AccessToken { get; set; }
    public string RefreshToken { get; set; }
}