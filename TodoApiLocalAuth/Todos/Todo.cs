namespace TodoApiLocalAuth.Todos;
public record Todo
{
    public Guid Id { get; init; }
    public string? Title { get; set; }
    public bool IsDone { get; set; } = false;
    public Guid UserId { get; init; }
}