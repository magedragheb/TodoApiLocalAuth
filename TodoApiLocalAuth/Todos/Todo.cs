namespace TodoApiLocalAuth.Todos;
public record Todo
{
    public int Id { get; init; }
    public string? Title { get; init; }
    public bool IsDone { get; init; } = false;
}