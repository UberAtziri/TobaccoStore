using AutoMapper;
using TobaccoStore.Entities;
using TobaccoStore.DTO;

namespace TobaccoStore.MappingProfile
{
    public class TobaccoMappings : Profile
    {
        public TobaccoMappings()
        {
            CreateMap<TobaccoEntity, TobaccoDto>().ReverseMap();
            CreateMap<TobaccoEntity, TobaccoUpdateDto>().ReverseMap();
            CreateMap<TobaccoEntity, TobaccoCreateDto>().ReverseMap();
            CreateMap<UserEntity, UserDTO>().ReverseMap();
            CreateMap<UserEntity, UserCreateDTO>().ReverseMap();
            CreateMap<UserEntity, UserUpdateDto>().ReverseMap();


        }
    }
}
