using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TodoApiLocalAuth.Data;

namespace TodoApiLocalAuth.Todos;

public class TodosService(IMapper mapper)
{
    public async Task<IResult> GetAllTodos(TodoDbContext db)
    => TypedResults.Ok(await db.Todos.Select(t => mapper.Map<TodoDTO>(t)).ToListAsync());

    public async Task<IResult> GetDoneTodos(TodoDbContext db)
        => TypedResults.Ok(await db.Todos.Where(t => t.IsDone)
        .Select(t => mapper.Map<TodoDTO>(t))
        .ToListAsync());

    public async Task<IResult> GetTodo(TodoDbContext db, string id)
        => await db.Todos.FindAsync(id)
        is Todo todo ? Results.Ok(mapper.Map<TodoDTO>(todo)) : TypedResults.NotFound(id);

    public async Task<IResult> CreateTodo(TodoDbContext db, TodoDTO todo)
    {
        var item = mapper.Map<Todo>(todo);
        // var item = new Todo { Title = todo.Title, IsDone = todo.IsDone };
        db.Todos.Add(item);
        await db.SaveChangesAsync();
        return TypedResults.Created($"/todos/{item.Id}", item);
    }

    public async Task<IResult> UpdateTodo(TodoDbContext db, TodoDTO input, string id)
    {
        var todo = await db.Todos.FindAsync(id);
        if (todo is null) return TypedResults.NotFound();

        todo = mapper.Map<Todo>(input);
        // todo.Title = input.Title;
        // todo.IsDone = input.IsDone;

        await db.SaveChangesAsync();
        return TypedResults.NoContent();
    }

    public async Task<IResult> DeleteTodo(TodoDbContext db, string id)
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