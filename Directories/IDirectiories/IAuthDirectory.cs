using Forum.Models;
using Forum.Models.Dtos;

namespace Forum.Directories.IDirectiories
{
    public interface IAuthDirectory
    {
        List<UserDto> GetUser();
        bool Adduser(User user);
    }
}
