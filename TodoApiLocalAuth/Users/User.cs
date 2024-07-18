using TodoApiLocalAuth.Todos;

namespace TodoApiLocalAuth.Users;

public class User
{
    public Guid Id { get; set; }
    public required string UserName { get; set; }
    public required string PasswordHash { get; set; } = "";
    public List<Todo> Todos { get; set; } = [];
}
