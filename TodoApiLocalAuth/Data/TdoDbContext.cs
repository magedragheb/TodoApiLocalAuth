using Microsoft.EntityFrameworkCore;
using TodoApiLocalAuth.Todos.Entity;
using TodoApiLocalAuth.Users.Entity;

namespace TodoApiLocalAuth.Data;

public class TodoDbContext(DbContextOptions<TodoDbContext> options) : DbContext(options)
{
    public DbSet<User> Users { get; set; }
    public DbSet<Todo> Todos { get; set; }
}

