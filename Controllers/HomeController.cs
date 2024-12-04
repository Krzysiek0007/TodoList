using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;
using TodoList.Models;
using TodoList.Services;

namespace TodoList.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUserContext _userContext;

        public HomeController(ILogger<HomeController> logger, IUserContext userContext)
        {
            _logger = logger;
            _userContext = userContext;
        }

        public IActionResult Index()
        {
            if (User.Identity?.IsAuthenticated ?? false) 
            { 
                _userContext.UserId = User.FindFirstValue(ClaimTypes.NameIdentifier); 
            }
            else
            {
                _userContext.UserId = null;
            }

            return View();
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
