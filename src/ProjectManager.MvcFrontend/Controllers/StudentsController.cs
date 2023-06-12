using Microsoft.AspNetCore.Mvc;
using ProjectManager.DomainModel.Interfaces;
using ProjectManager.DomainModel.Models;
using ProjectManager.Infrastructure;

namespace ProjectManager.MvcFrontend.Controllers
{
    public class StudentsController : Controller
    {
        private readonly IStudentService _studentService;
        private readonly ProjectManagerContext _context;
        public StudentsController(IStudentService studentService)
        {
            _studentService = studentService;
        }
        public IActionResult Index()
        {
            IEnumerable<Student> students = _studentService.GetAll();
            return View(students);
        }

    }
}
