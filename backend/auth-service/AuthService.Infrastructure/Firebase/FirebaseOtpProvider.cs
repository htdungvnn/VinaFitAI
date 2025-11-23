using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using AuthService.Application.Interfaces;
using Microsoft.Extensions.Configuration;

namespace AuthService.Infrastructure.Firebase;

public class FirebaseOtpProvider : IFirebaseOtpProvider
{
    private readonly HttpClient _http;
    private readonly IConfiguration _cfg;

    public FirebaseOtpProvider(IConfiguration cfg, HttpClient httpClient)
    {
        _cfg = cfg;
        _http = httpClient;

        _http.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));
    }

    public async Task SendOtp(string phone)
    {
        var firebase = _cfg.GetSection("Firebase");
        var apiKey = firebase["ApiKey"];
        var url = firebase["SendOtpUrl"] + apiKey;

        var payload = new
        {
            phoneNumber = phone,
            recaptchaToken = "unused"   // Mobile app must handle this normally
        };

        var content = new StringContent(
            JsonSerializer.Serialize(payload),
            Encoding.UTF8,
            "application/json");

        var response = await _http.PostAsync(url, content);

        if (!response.IsSuccessStatusCode)
        {
            var body = await response.Content.ReadAsStringAsync();
            throw new Exception($"Firebase send OTP failed: {body}");
        }
    }

    public async Task<bool> VerifyOtp(string phone, string code)
    {
        var firebase = _cfg.GetSection("Firebase");
        var apiKey = firebase["ApiKey"];
        var url = firebase["VerifyOtpUrl"] + apiKey;

        var payload = new
        {
            sessionInfo = phone,   // usually API returns sessionInfo; placeholder if mobile not handled
            code = code
        };

        var content = new StringContent(
            JsonSerializer.Serialize(payload),
            Encoding.UTF8,
            "application/json");

        var response = await _http.PostAsync(url, content);

        var responseBody = await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode)
        {
            return false;
        }

        // Firebase success response contains IDToken
        return responseBody.Contains("idToken");
    }
}