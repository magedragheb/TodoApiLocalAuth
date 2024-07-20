using TodoApiLocalAuth.Endpoints;

namespace TodoApiLocalAuth.Todos;

public class TodoEndpoint : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/todos");
        group.MapGet("/", (TodosService service) => service.GetAllTodos);
        group.MapGet("/done", (TodosService service) => service.GetDoneTodos);
        group.MapGet("/{id}", (TodosService service, string id) => service.GetTodo);
        group.MapPost("/", (TodosService service) => service.CreateTodo);
        group.MapPut("/{id}", (TodosService service, string id) => service.UpdateTodo);
        group.MapDelete("/{id}", (TodosService service, string id) => service.DeleteTodo);
    }

}