using Forum.Models;
using Forum.Models.Dtos;

namespace Forum.Services.IServices
{
    public interface IHome
    {
        IList<PostDto> getpost();
        PostDto getpostbyId(int? Id);
        void Add(Post data);
        bool DeletebyId(int? postId);
        List<UserDto> GetUser();
        bool Adduser(User user);
        UserDto LogIn(UserDto user);
    }
}
