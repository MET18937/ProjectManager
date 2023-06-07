using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bogus;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcProject.WebApplication.Data;
using MvcProject.WebApplication.Models;

namespace MvcProject.WebApplication.Controllers
{
    public class ProjectsController : Controller
    {
        private readonly MvcProjectWebApplicationContext _context;

        public ProjectsController(MvcProjectWebApplicationContext context)
        {
            _context = context;
        }

        //// GET: Projects
        //public async Task<IActionResult> Index()
        //{
        //    var mvcProjectWebApplicationContext = _context.Project.Include(p => p.Company).Include(p => p.Supervisor).Include(p => p.Teacher);
        //    return View(await mvcProjectWebApplicationContext.ToListAsync());
        //}

        public async Task<IActionResult> Index(string sortOrder, string searchString, string currentFilter, int? pageNumber)
        {
            ViewData["CurrentSort"] = sortOrder;
            ViewData["TitleSortParm"] = String.IsNullOrEmpty(sortOrder) ? "title_desc" : "";
            ViewData["DateSortParm"] = sortOrder == "Date" ? "date_desc" : "Date";
            if (searchString != null) pageNumber = 1;
            else searchString = currentFilter;
            ViewData["CurrentFilter"] = searchString;
            var projects = from p in _context.Project
                           select p;
            if (!String.IsNullOrEmpty(searchString))
            {
                projects = projects.Where(p => p.Title.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "title_desc":
                    projects = projects.OrderByDescending(p => p.Title);
                    break;
                case "Date":
                    projects = projects.OrderBy(p => p.SubmitDate);
                    break;
                case "date_desc":
                    projects = projects.OrderByDescending(p => p.SubmitDate);
                    break;
                default:
                    projects = projects.OrderBy(p => p.Title);
                    break;
            }
            int pageSize = 10;
            return View(await PaginatedList<Project>.CreateAsync(projects.AsNoTracking(), pageNumber ?? 1, pageSize));
        }



        // GET: Projects/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Project == null)
            {
                return NotFound();
            }

            var project = await _context.Project
                .Include(p => p.Company)
                .Include(p => p.Supervisor)
                .Include(p => p.Teacher)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (project == null)
            {
                return NotFound();
            }

            return View(project);
        }

        // GET: Projects/Create
        public IActionResult Create()
        {
            ViewData["CompanyId"] = new SelectList(_context.Company, "Id", "Id");
            ViewData["SupervisorId"] = new SelectList(_context.Supervisor, "Id", "Id");
            ViewData["TeacherId"] = new SelectList(_context.Teacher, "Id", "Id");
            return View();
        }

        // POST: Projects/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Title,Description,SubmitDate,SupervisorId,CompanyId,TeacherId,Id")] Project project)
        {
            if (ModelState.IsValid)
            {
                _context.Add(project);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CompanyId"] = new SelectList(_context.Company, "Id", "Id", project.CompanyId);
            ViewData["SupervisorId"] = new SelectList(_context.Supervisor, "Id", "Id", project.SupervisorId);
            ViewData["TeacherId"] = new SelectList(_context.Teacher, "Id", "Id", project.TeacherId);
            return View(project);
        }

        // GET: Projects/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Project == null)
            {
                return NotFound();
            }

            var project = await _context.Project.FindAsync(id);
            if (project == null)
            {
                return NotFound();
            }
            ViewData["CompanyId"] = new SelectList(_context.Company, "Id", "Id", project.CompanyId);
            ViewData["SupervisorId"] = new SelectList(_context.Supervisor, "Id", "Id", project.SupervisorId);
            ViewData["TeacherId"] = new SelectList(_context.Teacher, "Id", "Id", project.TeacherId);
            return View(project);
        }

        // POST: Projects/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Title,Description,SubmitDate,SupervisorId,CompanyId,TeacherId,Id")] Project project)
        {
            if (id != project.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(project);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProjectExists(project.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CompanyId"] = new SelectList(_context.Company, "Id", "Id", project.CompanyId);
            ViewData["SupervisorId"] = new SelectList(_context.Supervisor, "Id", "Id", project.SupervisorId);
            ViewData["TeacherId"] = new SelectList(_context.Teacher, "Id", "Id", project.TeacherId);
            return View(project);
        }

        // GET: Projects/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Project == null)
            {
                return NotFound();
            }

            var project = await _context.Project
                .Include(p => p.Company)
                .Include(p => p.Supervisor)
                .Include(p => p.Teacher)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (project == null)
            {
                return NotFound();
            }

            return View(project);
        }

        // POST: Projects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Project == null)
            {
                return Problem("Entity set 'MvcProjectWebApplicationContext.Project'  is null.");
            }
            var project = await _context.Project.FindAsync(id);
            if (project != null)
            {
                _context.Project.Remove(project);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProjectExists(int id)
        {
            return (_context.Project?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}