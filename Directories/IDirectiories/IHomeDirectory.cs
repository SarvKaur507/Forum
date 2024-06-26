using Forum.Models;
using Forum.Models.Dtos;

namespace Forum.Directories.IDirectiories
{
    public interface IHomeDirectory
    {
        IList<PostDto> getpost();
        PostDto getpostbyId(int? Id);
        void Add(Post data);
        bool DeletebyId(int? postId);

    }
}
