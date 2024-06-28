using Forum.Directories.IDirectiories;
using Forum.Models.Dtos;
using Forum.Models;
using Microsoft.AspNetCore.Authentication;
using AutoMapper;
using Forum.Models.Common;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

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
                var data = _context.Users.Select(x => new UserMapperDto
                {
                    Username = x.Username,
                    Password = x.Password??"",
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    PhoneNo = x.PhoneNo ?? 0
                }).ToList();
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
                string salt = CryptographyHelper.GenerateSalt();
                User users = new User();
                users.FirstName = user.FirstName;
                users.LastName = user.LastName;
                users.Username = user.Username;
                users.EMail = user.EMail;
                users.PasswordSalt = salt;
                users.PasswordHash = CryptographyHelper.HashPassword(salt, user.Password);
                var data = _context.Users.Add(users);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                throw;
            }
        }

        public UserDto LogIn(UserDto user)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(user.EMail))
                    throw new Exception($"Parameter 'username' cannot be null.");

                var UserLogin = _context.Users.Where(x => x.EMail == user.EMail).Select(x => new UserMapperDto
                {
                    Username = x.Username,
                   // Password = x.Password,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    PhoneNo = x.PhoneNo ?? 0,
                    PasswordHash = x.PasswordHash,
                    PasswordSalt = x.PasswordSalt
                }).FirstOrDefault();
                if (UserLogin == null)
                    throw new Exception($"We could not find an account with that email.");

                if (UserLogin != null)
                {
                    var passwordhash = CryptographyHelper.HashPassword(UserLogin.PasswordSalt, user.Password);
                    if (!UserLogin.PasswordHash.Equals(passwordhash))
                    {
                        throw new Exception("Password Not Match.");
                    }
                }
            }
            catch
            {
                throw;
            }
            return new UserDto { Id = user.Id, Username = user.FirstName, Password = user.Password };
        }
    }
}

