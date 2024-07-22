using TodoApiLocalAuth.Todos.Entity;

namespace TodoApiLocalAuth.Todos.Repo;

public interface ITodoRepo
{
    Task<IEnumerable<Todo>> GetAllTodos();
    Task<IEnumerable<Todo>> GetDoneTodos();
    Task<Todo?> GetTodo(Guid id);
    Task<Todo> CreateTodo(Todo todo);
    Task<Todo?> UpdateTodo(Guid id, Todo input);
    Task<bool> DeleteTodo(Guid id);
}