using AutoMapper;
using TodoApiLocalAuth.Todos.DTO;
using TodoApiLocalAuth.Todos.Entity;

namespace TodoApiLocalAuth.Todos.MappingProfile;

public class TodoMappingProfile : Profile
{
    public TodoMappingProfile() => CreateMap<Todo, TodoDTO>().ReverseMap();
}