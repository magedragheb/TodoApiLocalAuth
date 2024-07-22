using TodoApiLocalAuth.Todos.DTO;

namespace TodoApiLocalAuth.Todos.Service;

public interface ITodoService
{
    Task<IResult> GetAllTodos();
    Task<IResult> GetDoneTodos();
    Task<IResult> GetTodo(Guid id);
    Task<IResult> CreateTodo(TodoDTO todoDto);
    Task<IResult> UpdateTodo(Guid id, TodoDTO todoDto);
    Task<IResult> DeleteTodo(Guid id);
}