using Microsoft.AspNetCore.Mvc;
using ProjectManager.DomainModel.Interfaces;
using ProjectManager.Infrastructure;

namespace ProjectManager.MvcFrontend.Controllers
{
    public class TeachersController : Controller
    {
        //private readonly ITeachersService _teachersService;
        private readonly ProjectManagerContext _context;
        //public TeachersController(ITeachersService teachersService)
        //{
        //    _teachersService = teachersService;
        //}

        public IActionResult Index()
        {
            var date = _context.Teachers.ToList();
            return View(date);
        }
    }
}
