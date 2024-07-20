using AutoMapper;

namespace TodoApiLocalAuth.Todos;

public class TodoMappingProfile : Profile
{
    public TodoMappingProfile() => CreateMap<Todo, TodoDTO>().ReverseMap();
}