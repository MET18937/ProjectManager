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
    public class SupervisorsController : Controller
    {
        private readonly MvcProjectWebApplicationContext _context;

        public SupervisorsController(MvcProjectWebApplicationContext context)
        {
            _context = context;
        }

        // GET: Supervisors
        //public async Task<IActionResult> Index()
        //{
        //    var mvcProjectWebApplicationContext = _context.Supervisor.Include(s => s.Teacher);
        //    return View(await mvcProjectWebApplicationContext.ToListAsync());
        //}

        public async Task<IActionResult> Index(string sortOrder, string searchString)
        {
            ViewData["TeacherSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["CurrentFilter"] = searchString;
            var supervisor = from s in _context.Supervisor
                             select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                supervisor = supervisor.Where(s => s.TeacherId == int.Parse(searchString));
            }
            switch (sortOrder)
            {
                case "name_desc":
                    supervisor = supervisor.OrderByDescending(s => s.TeacherId);
                    break;

                default:
                    supervisor = supervisor.OrderBy(s => s.TeacherId);
                    break;
            }
            return View(await supervisor.AsNoTracking().ToListAsync());
        }



        // GET: Supervisors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Supervisor == null)
            {
                return NotFound();
            }

            var supervisor = await _context.Supervisor
                .Include(s => s.Teacher)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (supervisor == null)
            {
                return NotFound();
            }

            return View(supervisor);
        }

        // GET: Supervisors/Create
        public IActionResult Create()
        {
            ViewData["TeacherId"] = new SelectList(_context.Teacher, "Id", "Id");
            return View();
        }

        // POST: Supervisors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Description,TeacherId,Id")] Supervisor supervisor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(supervisor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TeacherId"] = new SelectList(_context.Teacher, "Id", "Id", supervisor.TeacherId);
            return View(supervisor);
        }

        // GET: Supervisors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Supervisor == null)
            {
                return NotFound();
            }

            var supervisor = await _context.Supervisor.FindAsync(id);
            if (supervisor == null)
            {
                return NotFound();
            }
            ViewData["TeacherId"] = new SelectList(_context.Teacher, "Id", "Id", supervisor.TeacherId);
            return View(supervisor);
        }

        // POST: Supervisors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Description,TeacherId,Id")] Supervisor supervisor)
        {
            if (id != supervisor.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(supervisor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SupervisorExists(supervisor.Id))
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
            ViewData["TeacherId"] = new SelectList(_context.Teacher, "Id", "Id", supervisor.TeacherId);
            return View(supervisor);
        }

        // GET: Supervisors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Supervisor == null)
            {
                return NotFound();
            }

            var supervisor = await _context.Supervisor
                .Include(s => s.Teacher)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (supervisor == null)
            {
                return NotFound();
            }

            return View(supervisor);
        }

        // POST: Supervisors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Supervisor == null)
            {
                return Problem("Entity set 'MvcProjectWebApplicationContext.Supervisor'  is null.");
            }
            var supervisor = await _context.Supervisor.FindAsync(id);
            if (supervisor != null)
            {
                _context.Supervisor.Remove(supervisor);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SupervisorExists(int id)
        {
            return (_context.Supervisor?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
