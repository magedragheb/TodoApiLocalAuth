using System.Reflection;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using TodoApiLocalAuth.Data;
using TodoApiLocalAuth.Endpoints;
using TodoApiLocalAuth.Todos.Repo;
using TodoApiLocalAuth.Todos.Service;
using TodoApiLocalAuth.Users.Repo;
using TodoApiLocalAuth.Users.Service;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<TodoDbContext>(options =>
    options.UseSqlite("Data Source=Data/todo.db"));
builder.Services.AddTransient<ITodoService, TodoService>();
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<ITodoRepo, TodoRepo>();
builder.Services.AddTransient<IUserRepo, UserRepo>();
builder.Services.AddHttpContextAccessor();
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
builder.Services.AddEndpoints(Assembly.GetExecutingAssembly());
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.AccessDeniedPath = "/Denied";
        options.Cookie.MaxAge = TimeSpan.FromDays(3);
        options.Cookie.Name = "TodoApiLocalAuth";
    });
builder.Services.AddAuthorization();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapEndpoints();

app.Run();
