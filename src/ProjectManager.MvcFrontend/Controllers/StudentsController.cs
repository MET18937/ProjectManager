using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectManager.DomainModel.Interfaces;
using ProjectManager.DomainModel.Models;
using ProjectManager.Infrastructure;

namespace ProjectManager.MvcFrontend.Controllers
{
    public class StudentsController : Controller
    {
        private readonly IStudentService _studentService;
        private readonly ProjectManagerContext _context;

        public StudentsController(IStudentService studentService, ProjectManagerContext context)
        {
            _studentService = studentService;
            _context = context;
        }

        public async Task<IActionResult> Index(string sortOrder, string currentFilter, string searchString, int? pageNumber)
        {
            ViewData["FirstnameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["LastNameSortParm"] = sortOrder == "LastName" ? "lastname_desc" : "LastName";
            ViewData["CurrentFilter"] = searchString;

            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            IQueryable<StudentDto> students = from s in _context.Students
                                           select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                students = students.Where(s => s.Firstname.Contains(searchString)
                                                      || s.Lastname.Contains(searchString) || s.Email.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "name_desc":
                    students = students.OrderByDescending(s => s.Firstname);
                    break;
                case "LastName":
                    students = students.OrderBy(s => s.Lastname);
                    break;
                case "lastname_desc":
                    students = students.OrderByDescending(s => s.Lastname);
                    break;
                default:
                    students = students.OrderBy(s => s.Firstname);
                    break;
            }
            int pageSize = 10;
            return View(await PaginatedList<StudentDto>.CreateAsync(students.AsNoTracking(), pageNumber ?? 1, pageSize));
        }
    }
}
