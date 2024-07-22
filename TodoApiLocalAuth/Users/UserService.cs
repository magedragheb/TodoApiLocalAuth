using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using AutoMapper;
using Isopoh.Cryptography.Argon2;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using TodoApiLocalAuth.Users.DTO;
using TodoApiLocalAuth.Users.Entity;
using TodoApiLocalAuth.Users.Repo;

namespace TodoApiLocalAuth.Users.Service;

public class UserService(
    IMapper mapper,
    IUserRepo repo,
    IHttpContextAccessor context) : IUserService
{
    public async Task<IResult> SignUp(UserDTO userDto)
    {
        var user = mapper.Map<User>(userDto);
        user.PasswordHash = Hash(userDto.Password);
        await repo.CreateUser(user);
        if (context.HttpContext is null) return TypedResults.BadRequest();
        await context.HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, GetPrincipal(user.Id.ToString()));
        return TypedResults.Ok(mapper.Map<ResultDTO>(user));
    }

    public async Task<IResult> SignIn(UserDTO userDto)
    {
        var user = await repo.GetUserByUserName(userDto.UserName);
        if (user is null) return TypedResults.NotFound();
        var result = Verify(user.PasswordHash, userDto.Password);
        if (!result) return TypedResults.Unauthorized();
        if (context.HttpContext is null) return TypedResults.BadRequest();
        await context.HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, GetPrincipal(user.Id.ToString()));
        return TypedResults.Ok(mapper.Map<ResultDTO>(user));
    }

    public async Task<IResult> SignOut()
    {
        if (context.HttpContext is null) return TypedResults.BadRequest();
        await context.HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        return TypedResults.Ok();
    }

    public string Hash(string secret)
    {
        var salt = new byte[16];
        RandomNumberGenerator.Fill(salt);
        var config = new Argon2Config
        {
            Salt = salt,
            Password = Encoding.UTF8.GetBytes(secret)
        };
        var hash = Argon2.Hash(config);
        return hash;
    }

    public bool Verify(string hash, string password) => Argon2.Verify(hash, password);

    public ClaimsPrincipal GetPrincipal(string userId)
    {
        var identity = new ClaimsIdentity([new Claim("Id", userId)], CookieAuthenticationDefaults.AuthenticationScheme);
        return new ClaimsPrincipal(identity);
    }
}