using Microsoft.AspNetCore.Mvc;

namespace ProjectManager.MvcFrontend.Controllers
{
    public class TeachersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
