using AutoMapper;
using TodoApiLocalAuth.Todos.DTO;
using TodoApiLocalAuth.Todos.Entity;
using TodoApiLocalAuth.Todos.Repo;

namespace TodoApiLocalAuth.Todos.Service;

public class TodoService(
    IMapper mapper, 
    ITodoRepo repo, 
    IHttpContextAccessor context) : ITodoService
{
    public async Task<IResult> GetAllTodos()
    {
        var todos = mapper.Map<IEnumerable<TodoDTO>>(await repo.GetAllTodos());
        return TypedResults.Ok(todos);
    }

    public async Task<IResult> GetDoneTodos()
    {
        var todos = mapper.Map<IEnumerable<TodoDTO>>(await repo.GetDoneTodos());
        return TypedResults.Ok(todos);
    }

    public async Task<IResult> GetTodo(Guid id)
    {
        var todo = mapper.Map<TodoDTO>(await repo.GetTodo(id));
        return todo is null ? TypedResults.NotFound() : TypedResults.Ok(todo);
    }

    public async Task<IResult> CreateTodo(TodoDTO todoDto)
    {
        var todo = mapper.Map<Todo>(todoDto);
        if (context.HttpContext is null) return TypedResults.BadRequest();
        var claim = context.HttpContext.User.Claims.FirstOrDefault(c => c.Type == "Id");
        if (claim is null) return TypedResults.Unauthorized();
        todo.UserId = new Guid(claim.Value);
        await repo.CreateTodo(todo);
        return TypedResults.Created($"/todos/{todo.Id}", todoDto);
    }

    public async Task<IResult> UpdateTodo(Guid id, TodoDTO input)
    {
        var item = mapper.Map<Todo>(input);
        var result = await repo.UpdateTodo(id, item);
        return result is null ? TypedResults.NotFound() : TypedResults.NoContent();
    }

    public async Task<IResult> DeleteTodo(Guid id)
    {
        var result = await repo.DeleteTodo(id);
        return result ? TypedResults.NoContent() : TypedResults.NotFound();
    }
}