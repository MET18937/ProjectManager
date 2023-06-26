using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ProjectManager.DomainModel.Models;

namespace ProjectManager.MvcFrontend
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            string message;
            if (Request.Cookies["login_56baif"] == null)
            {
                message = "nicht angemeldet";
            }
            else
            {
                message = "angemeldet";
            }
            return View("Index", message);
        }

        public IActionResult Privacy()
        {
            return View("Privacy");
        }
    }
}
