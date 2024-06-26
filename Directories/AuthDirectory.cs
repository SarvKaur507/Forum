using Forum.Directories.IDirectiories;
using Forum.Models.Dtos;
using Forum.Models;
using Microsoft.AspNetCore.Authentication;
using AutoMapper;

namespace Forum.Directories
{
    public class AuthDirectory : IAuthDirectory
    {
        private readonly ForumContext _context;
        private readonly IMapper _mapper;
        public AuthDirectory(ForumContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<UserDto> GetUser()
        {
            try
            {
                var data = _context.Users.Select(x => x).ToList();
                return _mapper.Map<List<UserDto>>(data);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public bool Adduser(User user)
        {
            try
            {
                var data = _context.Users.Add(user);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                throw;
            }

        }
    }
}
