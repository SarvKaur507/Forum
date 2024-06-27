using Forum.Models;
using Forum.Models.Dtos;
using Forum.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using static System.Runtime.InteropServices.JavaScript.JSType;

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
        public IActionResult Register(User user)
        {
            bool Data = _home.Adduser(user);
            if (Data)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "An error occurred while adding the user.");
                return View(user);
            }
        }
    }
}


