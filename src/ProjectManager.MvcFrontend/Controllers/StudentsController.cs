using Microsoft.AspNetCore.Mvc;

namespace ProjectManager.MvcFrontend.Controllers
{
    public class StudentsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
