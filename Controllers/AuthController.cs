using Forum.Models;
using Forum.Models.Dtos;
using Forum.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Forum.Controllers
{

    public class AuthController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ForumContext _forumContext;
        private readonly IHome _home;
        public AuthController(ILogger<HomeController> logger, ForumContext forumContext, IHome home)
        {
            _logger = logger;
            _forumContext = forumContext;
            _home = home;
        }
        [HttpGet]
        public IActionResult Register()
        {
            List<UserDto> data = _home.GetUser();
            return View();
        }

        [HttpPost]
        public IActionResult Registration(User user)
        {
            bool Data = _home.Adduser(user);



            return RedirectToAction("Home/Index");
        }
    }
}


