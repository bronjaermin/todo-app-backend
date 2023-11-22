using AutoMapper;
using Todo.Data;
using Todo.DTOs;

namespace Todo.Profiles
{
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {
            CreateMap<User, UserResponseDTO>();
        }
    }
}
