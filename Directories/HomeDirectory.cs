using AutoMapper;
using Forum.Directories.IDirectiories;
using Forum.Models;
using Forum.Models.Dtos;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Forum.Directories
{
   
    public class HomeDirectory : IHomeDirectory
    {
        private readonly ForumContext _forumContext;
        protected readonly IMapper _mapper;
       
        public HomeDirectory(ForumContext forumContext, IMapper mapper)
        {
            _forumContext = forumContext;
            _mapper = mapper;
        }
        public IList<PostDto> getpost()
        {
            var data = _forumContext.Posts.ToList();
             return _mapper.Map<IList<PostDto>>(data);
        }
        public PostDto getpostbyId(int? Id)
        {
            var data = _forumContext.Posts.FirstOrDefault(x=> x.PostId == Id);
            return _mapper.Map<PostDto>(data);
        }
        public void Add(Post data)
        {
            if(data.PostId == 0)
            {
                var res = _forumContext.Posts.Add(data);
                _forumContext.SaveChanges();
            }
            else
            {
                var id = _forumContext.Posts.Any(x=> x.PostId == data.PostId);
                if(id)
                {
                    Post post = new Post();
                    post.Content = data.Content;
                    post.PosType = data.PosType;
                    _forumContext.Posts.Update(post);
                }
                _forumContext.SaveChanges();
            }
        }
        public bool DeletebyId(int? postId)
        {
            var Post = _forumContext.Posts.Find(postId);
            if(Post != null)
            {
                _forumContext.Posts.Remove(Post);
                _forumContext.SaveChangesAsync();
                return true;
            }
            else { return false; }
          
        }
    }
}
