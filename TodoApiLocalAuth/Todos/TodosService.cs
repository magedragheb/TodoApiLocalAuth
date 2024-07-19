using Microsoft.EntityFrameworkCore;
using TodoApiLocalAuth.Data;

namespace TodoApiLocalAuth.Todos;

public class TodosService
{
    public static async Task<IResult> GetAllTodos(TodoDbContext db)
    => TypedResults.Ok(await db.Todos.ToListAsync());

    public static async Task<IResult> GetDoneTodos(TodoDbContext db)
        => TypedResults.Ok(await db.Todos.Where(t => t.IsDone)
        .ToListAsync());

    public static async Task<IResult> GetTodo(TodoDbContext db, string id)
        => await db.Todos.FindAsync(id)
        is Todo todo ? Results.Ok(todo) : TypedResults.NotFound(id);

    public static async Task<IResult> CreateTodo(TodoDbContext db, TodoDTO todo)
    {
        var item = new Todo { IsDone = todo.IsDone, Title = todo.Title };
        db.Todos.Add(item);
        await db.SaveChangesAsync();
        return TypedResults.Created($"/todos/{item.Id}", item);
    }

    public static async Task<IResult> UpdateTodo(TodoDbContext db, TodoDTO input, string id)
    {
        var todo = await db.Todos.FindAsync(id);
        if (todo is null) return TypedResults.NotFound();

        todo.Title = input.Title;
        todo.IsDone = input.IsDone;

        await db.SaveChangesAsync();
        return TypedResults.NoContent();
    }

    public static async Task<IResult> DeleteTodo(TodoDbContext db, string id)
    {
        if (await db.Todos.FindAsync(id) is Todo todo)
        {
            db.Todos.Remove(todo);
            await db.SaveChangesAsync();
            return Results.NoContent();
        }

        return TypedResults.NotFound();
    }
}