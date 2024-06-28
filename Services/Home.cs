using AutoMapper;
using Forum.Directories.IDirectiories;
using Forum.Models;
using Forum.Models.Dtos;
using Forum.Services.IServices;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace Forum.Services
{
    public class Home : IHome
    {
        private readonly IHomeDirectory _home;
        private readonly IMapper _mapper;
        protected readonly IAuthDirectory _authDirectory;
        public Home(IHomeDirectory home, IMapper mapper, IAuthDirectory authDirectory)
        {
            _home = home;
            _mapper = mapper;
            _authDirectory = authDirectory;
        }
        public IList<PostDto> getpost()
        {
            var data = _home.getpost();
            return _mapper.Map<IList<PostDto>>(data);
        }
        public PostDto getpostbyId(int? Id)
        {
            var data = _home.getpostbyId(Id);
            return _mapper.Map<PostDto>(data);
        }
        public void Add(Post data) 
        {
            _home.Add(data);
        }
        public bool DeletebyId(int? postId)
        {
            var data = _home.DeletebyId(postId);
            if(data != null)
            {
                return true;
            }
            return false;
        }
        public List<UserDto> GetUser()
        {
            var data = _authDirectory.GetUser();
            return _mapper.Map<List<UserDto>>(data);
        }
        public bool Adduser(User user)
        {
            var data = _authDirectory.Adduser(user);
            return true;
        }
        public UserDto LogIn(UserDto user)
        {
            UserDto dto = new UserDto();
            var data = _authDirectory.LogIn(user);
            return dto;
        }

    }
}
