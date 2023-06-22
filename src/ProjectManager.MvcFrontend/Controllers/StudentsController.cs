using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectManager.Application.Services;
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

        //public async Task<IActionResult> Index(string sortOrder, string currentFilter, string searchString, int? pageNumber)
        //{
        //    ViewData["FirstnameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
        //    ViewData["LastNameSortParm"] = sortOrder == "LastName" ? "lastname_desc" : "LastName";
        //    ViewData["CurrentFilter"] = searchString;

        //    if (searchString != null)
        //    {
        //        pageNumber = 1;
        //    }
        //    else
        //    {
        //        searchString = currentFilter;
        //    }
        //    IQueryable<StudentDto> students = from s in _context.Students
        //                                      select s;

        //    if (!String.IsNullOrEmpty(searchString))
        //    {
        //        students = students.Where(s => s.Firstname.Contains(searchString)
        //                                              || s.Lastname.Contains(searchString) || s.Email.Contains(searchString));
        //    }
        //    switch (sortOrder)
        //    {
        //        case "name_desc":
        //            students = students.OrderByDescending(s => s.Firstname);
        //            break;
        //        case "LastName":
        //            students = students.OrderBy(s => s.Lastname);
        //            break;
        //        case "lastname_desc":
        //            students = students.OrderByDescending(s => s.Lastname);
        //            break;
        //        default:
        //            students = students.OrderBy(s => s.Firstname);
        //            break;
        //    }
        //    int pageSize = 10;
        //    return View(await PaginatedList<StudentDto>.CreateAsync(students.AsNoTracking(), pageNumber ?? 1, pageSize));
        //}



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
            var students = _studentService.GetAll();

            var studentFilterService = new StudentFilterService(sortOrder);
            var studentSearchService = new StudentSearchService(currentFilter, searchString, pageNumber);

            students = studentFilterService.Apply(students);
            students = studentSearchService.Apply(students);

            int pageSize = 10;
            return View(await PaginatedList<StudentDto>.CreateAsync(students.AsNoTracking(), pageNumber ?? 1, pageSize));
        }




        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Firstname,Lastname,Email,Id")] StudentDto student)
        {
            if (ModelState.IsValid)
            {
                _studentService.Add(student);
                return RedirectToAction(nameof(Index));
            }
            return View(student);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _studentService.GetAll() == null)
            {
                return NotFound();
            }
            var student = _studentService.GetById(id.Value);
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Firstname,Lastname,Email,Id")] StudentDto student)
        {
            if (id != student.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _studentService.Update(student);
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(student);
        }
    }
}
