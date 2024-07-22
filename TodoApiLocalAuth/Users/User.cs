using TodoApiLocalAuth.Todos.Entity;

namespace TodoApiLocalAuth.Users.Entity;

public record User
{
    public Guid Id { get; init; }
    public required string UserName { get; set; }
    public required string PasswordHash { get; set; }
    public List<Todo> Todos { get; set; } = [];
}
