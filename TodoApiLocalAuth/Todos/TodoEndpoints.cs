using TodoApiLocalAuth.Endpoints;
using TodoApiLocalAuth.Todos.DTO;
using TodoApiLocalAuth.Todos.Service;

namespace TodoApiLocalAuth.Todos.Endpoints;

public class TodoEndpoints : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/todos");

        group.WithDisplayName("Todos");

        group.MapGet("/", (ITodoService service) => service.GetAllTodos());

        group.MapGet("/done", (ITodoService service) => service.GetDoneTodos());

        group.MapGet("/{id}", (ITodoService service, Guid id) => service.GetTodo(id));

        group.MapPost("/", (ITodoService service, TodoDTO todoDto) => service.CreateTodo(todoDto));

        group.MapPut("/{id}", (ITodoService service, Guid id, TodoDTO todoDto) => service.UpdateTodo(id, todoDto));

        group.MapDelete("/{id}", (ITodoService service, Guid id) => service.DeleteTodo(id));
    }

}