using AuthService.Application.Interfaces;
using AuthService.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AuthService.Infrastructure.Persistence;

public class UserRepository : IUserRepository
{
    private readonly AuthDbContext _db;

    public UserRepository(AuthDbContext db)
    {
        _db = db;
    }

    public async Task<User> GetOrCreateAsync(string phone)
    {
        var user = await _db.Users.FirstOrDefaultAsync(x => x.Phone == phone);
        if (user != null) return user;

        var newUser = new User { Phone = phone };
        _db.Users.Add(newUser);
        await _db.SaveChangesAsync();
        return newUser;
    }
}