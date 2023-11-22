using AutoMapper;
using Todo.Data;
using Todo.DTOs;

namespace Todo.Profiles
{
    public class ItemsMappingProfile : Profile
    {
        public ItemsMappingProfile()
        {
            CreateMap<Item, ItemResponseDTO>();
            CreateMap<ItemRequestDTO, Item>();
            CreateMap<ItemUpdateRequestDTO, Item>();
        }
    }
}
