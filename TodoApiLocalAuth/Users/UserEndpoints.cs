using TodoApiLocalAuth.Endpoints;
using TodoApiLocalAuth.Users.DTO;
using TodoApiLocalAuth.Users.Service;

namespace TodoApiLocalAuth.Users.Endpoints;

public class UserEndpoints : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/users");

        group.WithDisplayName("Users");

        group.MapPost("/signup", (IUserService service, UserDTO userDto) => service.SignUp(userDto));

        group.MapPost("/signin", (IUserService service, UserDTO userDto) => service.SignIn(userDto));

        group.MapPost("/signout", (IUserService service) => service.SignOut());
    }
}