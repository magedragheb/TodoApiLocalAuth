namespace TodoApiLocalAuth.Todos;

public class TodoEndpoint
{
    public static void MapEndpoint(IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/todos");
        group.MapGet("/", TodosService.GetAllTodos);
        group.MapGet("/done", TodosService.GetDoneTodos);
        group.MapGet("/{id}", TodosService.GetTodo);
        group.MapPost("/", TodosService.CreateTodo);
        group.MapPut("/{id}", TodosService.UpdateTodo);
        group.MapDelete("/{id}", TodosService.DeleteTodo);
    }

}