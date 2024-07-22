using TodoApiLocalAuth.Users.DTO;

namespace TodoApiLocalAuth.Users.Service;

public interface IUserService
{
    Task<IResult> SignUp(UserDTO userDto);
    Task<IResult> SignIn(UserDTO userDto);
    Task<IResult> SignOut();
}