using AutoMapper;
using TodoApiLocalAuth.Users.DTO;
using TodoApiLocalAuth.Users.Entity;

namespace TodoApiLocalAuth.Users.MappingProfile;

public class UserMappingProfile : Profile
{
    public UserMappingProfile()
    {
        CreateMap<User, UserDTO>().ReverseMap();
        CreateMap<User, ResultDTO>();
    }
}