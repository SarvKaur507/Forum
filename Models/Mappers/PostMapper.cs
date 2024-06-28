using AutoMapper;
using Forum.Models.Dtos;

namespace Forum.Models.Mappers
{
    public class PostMapper : Profile
    {
        public PostMapper()
        {
            CreateMap<User, UserMapperDto>()
          .ForMember(dest => dest.PhoneNo, opt => opt.MapFrom(src => src.PhoneNo ?? 0)); // Handle nulls
            CreateMap<UserMapperDto, UserDto>(); // Map to the final DTO
            CreateMap<Post, PostDto>().ReverseMap();
            CreateMap<User, UserDto>().ReverseMap();
        }
    }

}
