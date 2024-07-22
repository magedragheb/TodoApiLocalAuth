namespace TodoApiLocalAuth.Users.DTO;

public record UserDTO
{
    public required string UserName { get; set; }
    public required string Password { get; set; }
}

public record ResultDTO
{
    public required string UserName { get; set; }
}