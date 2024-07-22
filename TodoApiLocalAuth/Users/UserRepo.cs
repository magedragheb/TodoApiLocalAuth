using Microsoft.EntityFrameworkCore;
using TodoApiLocalAuth.Data;
using TodoApiLocalAuth.Users.Entity;

namespace TodoApiLocalAuth.Users.Repo;

public class UserRepo(TodoDbContext db) : IUserRepo
{
    public async Task<User?> GetUserByUserName(string username) => 
    await db.Users.Where(u => u.UserName == username).AsNoTracking().FirstOrDefaultAsync();

    public async Task<User?> GetUserById(Guid id) => await db.Users.FindAsync(id);

    public async Task<User> CreateUser(User user)
    {
        await db.Users.AddAsync(user);
        await db.SaveChangesAsync();
        return user;
    }

    public async Task<User?> UpdateUser(Guid id, User input)
    {
        var user = await db.Users.FindAsync(id);
        if (user is null) return null;
        user.UserName = input.UserName;
        user.PasswordHash = input.PasswordHash;
        await db.SaveChangesAsync();
        return user;
    }

    public async Task<bool> DeleteUser(Guid id)
    {
        var user = await db.Users.FindAsync(id);
        if (user is null) return false;
        db.Users.Remove(user);
        await db.SaveChangesAsync();
        return true;
    }

}
