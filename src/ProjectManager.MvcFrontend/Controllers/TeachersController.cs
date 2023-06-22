using Microsoft.AspNetCore.Mvc;
using ProjectManager.DomainModel.Interfaces;
using ProjectManager.DomainModel.Models;
using ProjectManager.Infrastructure;

namespace ProjectManager.MvcFrontend.Controllers
{
    public class TeachersController : Controller
    {
        private readonly ITeachersService _teachersService;
        private readonly ProjectManagerContext _context;
        public TeachersController(ITeachersService teachersService)
        {
            _teachersService = teachersService;
        }

        public IActionResult Index()
        {
            IEnumerable<TeacherDto> teachers = _teachersService.GetAll();
            return View(teachers);
        }
    }
}
