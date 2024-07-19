using Microsoft.EntityFrameworkCore;
using TodoApiLocalAuth.Todos;
using TodoApiLocalAuth.Users;

namespace TodoApiLocalAuth.Data;

public class TodoDbContext(DbContextOptions<TodoDbContext> options) : DbContext(options)
{
    public DbSet<User> Users { get; set; }
    public DbSet<Todo> Todos { get; set; }
}

