namespace AuthService.Domain.Entities;

public class User
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Phone { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}