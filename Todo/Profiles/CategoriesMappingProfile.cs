using AutoMapper;
using Todo.Data;
using Todo.DTOs;

namespace Todo.Profiles
{
    public class CategoriesMappingProfile : Profile
    {
        public CategoriesMappingProfile()
        {
            CreateMap<Category, CategoryResponseDTO>();
            CreateMap<CategoryRequestDTO, Category>();
        }
    }
}
