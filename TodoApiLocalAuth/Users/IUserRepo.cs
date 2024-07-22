using TodoApiLocalAuth.Users.Entity;

namespace TodoApiLocalAuth.Users.Repo;

public interface IUserRepo
{
    Task<User?> GetUserByUserName(string username);
    Task<User?> GetUserById(Guid id);
    Task<User> CreateUser(User user);
    Task<User?> UpdateUser(Guid id, User input);
    Task<bool> DeleteUser(Guid id);
}