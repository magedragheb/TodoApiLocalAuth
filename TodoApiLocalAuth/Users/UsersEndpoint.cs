using TodoApiLocalAuth.Endpoints;

namespace TodoApiLocalAuth.Users;

public class UsersEndpoint : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/users");
        group.MapGet("/signup", UsersService.SignUp);
        group.MapGet("/signin", UsersService.SignIn);
        group.MapGet("/signout", UsersService.SignOut);
    }
}