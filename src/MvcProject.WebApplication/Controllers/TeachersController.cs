using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcProject.WebApplication.Data;
using MvcProject.WebApplication.Models;

namespace MvcProject.WebApplication.Controllers
{
    public class TeachersController : Controller
    {
        private readonly MvcProjectWebApplicationContext _context;

        public TeachersController(MvcProjectWebApplicationContext context)
        {
            _context = context;
        }

        // GET: Teachers
        //public async Task<IActionResult> Index()
        //{
        //      return _context.Teacher != null ? 
        //                  View(await _context.Teacher.ToListAsync()) :
        //                  Problem("Entity set 'MvcProjectWebApplicationContext.Teacher'  is null.");
        //}

        public async Task<IActionResult> Index(string sortOrder)
        {
            ViewData["LastnameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "lastname_desc" : "";
            ViewData["FirstnameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "firstname_desc" : "firstname";
            var teachers = from s in _context.Teacher
                           select s;
            switch (sortOrder)
            {
                case "lastname_desc":
                    teachers = teachers.OrderByDescending(s => s.Lastname);
                    break;
                case "firstname":
                    teachers = teachers.OrderBy(s => s.Firstname);
                    break;
                case "firstname_desc":
                    teachers = teachers.OrderByDescending(s => s.Firstname);
                    break;
                default:
                    teachers = teachers.OrderBy(s => s.Lastname);
                    break;
            }
            return View(await teachers.AsNoTracking().ToListAsync());
        }




        // GET: Teachers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Teacher == null)
            {
                return NotFound();
            }

            var teacher = await _context.Teacher
                .FirstOrDefaultAsync(m => m.Id == id);
            if (teacher == null)
            {
                return NotFound();
            }

            return View(teacher);
        }

        // GET: Teachers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Teachers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Firstname,Lastname,Email,Id")] Teacher teacher)
        {
            if (ModelState.IsValid)
            {
                _context.Add(teacher);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(teacher);
        }

        // GET: Teachers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Teacher == null)
            {
                return NotFound();
            }

            var teacher = await _context.Teacher.FindAsync(id);
            if (teacher == null)
            {
                return NotFound();
            }
            return View(teacher);
        }

        // POST: Teachers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Firstname,Lastname,Email,Id")] Teacher teacher)
        {
            if (id != teacher.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(teacher);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TeacherExists(teacher.Id))
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
            return View(teacher);
        }

        // GET: Teachers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Teacher == null)
            {
                return NotFound();
            }

            var teacher = await _context.Teacher
                .FirstOrDefaultAsync(m => m.Id == id);
            if (teacher == null)
            {
                return NotFound();
            }

            return View(teacher);
        }

        // POST: Teachers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Teacher == null)
            {
                return Problem("Entity set 'MvcProjectWebApplicationContext.Teacher'  is null.");
            }
            var teacher = await _context.Teacher.FindAsync(id);
            if (teacher != null)
            {
                _context.Teacher.Remove(teacher);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TeacherExists(int id)
        {
            return (_context.Teacher?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
