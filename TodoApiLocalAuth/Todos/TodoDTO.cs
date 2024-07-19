namespace TodoApiLocalAuth.Todos;

public record TodoDTO
{
    public string? Title {get; init;}
    public bool IsDone {get; init;}
}