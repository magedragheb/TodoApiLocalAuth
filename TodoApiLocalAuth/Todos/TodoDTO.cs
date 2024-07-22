namespace TodoApiLocalAuth.Todos.DTO;

public record TodoDTO
{
    public required string Title { get; set; }
    public bool IsDone { get; set; } = false;
}