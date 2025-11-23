namespace AuthService.Application.DTOs;

public class ResultMessage
{
    public bool Success { get; set; }
    public string Message { get; set; }

    public static ResultMessage Ok(string msg) =>
        new ResultMessage { Success = true, Message = msg };
}