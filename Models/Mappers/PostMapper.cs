using AutoMapper;
using Forum.Models.Dtos;

namespace Forum.Models.Mappers
{
    public class PostMapper : Profile
    {
        public PostMapper()
        {
            CreateMap<Post, PostDto>().ReverseMap();
            CreateMap<User, UserDto>().ReverseMap();
        }
    }

}
