using Forum.Models;
using Forum.Models.Dtos;
using Forum.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Forum.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ForumContext _forumContext;
        private readonly IHome _home;
        public HomeController(ILogger<HomeController> logger , ForumContext forumContext, IHome home)
        {
            _logger = logger;
            _forumContext = forumContext;
            _home = home;
        }

        public IActionResult Index()
        {
            IList<PostDto> result = _home.getpost();
            return View(result);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Post data)
        {
             _home.Add(data);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(int? postId)
        {
           PostDto data = _home.getpostbyId(postId);
            return View(data);
        }
        [HttpDelete]
        public IActionResult Delete(int? postId)
        {
            bool data = _home.DeletebyId(postId);
            if(data)
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }

}
