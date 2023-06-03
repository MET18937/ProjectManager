using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcProject.WebApplication.Data;
using Spg.ProjectManager.Application.Models;

namespace MvcProject.WebApplication.Controllers
{
    public class StudentHasProjectsController : Controller
    {
        private readonly MvcProjectWebApplicationContext _context;

        public StudentHasProjectsController(MvcProjectWebApplicationContext context)
        {
            _context = context;
        }

        // GET: StudentHasProjects
        public async Task<IActionResult> Index()
        {
              return _context.StudentHasProject != null ? 
                          View(await _context.StudentHasProject.ToListAsync()) :
                          Problem("Entity set 'MvcProjectWebApplicationContext.StudentHasProject'  is null.");
        }

        // GET: StudentHasProjects/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.StudentHasProject == null)
            {
                return NotFound();
            }

            var studentHasProject = await _context.StudentHasProject
                .FirstOrDefaultAsync(m => m.Id == id);
            if (studentHasProject == null)
            {
                return NotFound();
            }

            return View(studentHasProject);
        }

        // GET: StudentHasProjects/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: StudentHasProjects/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StudentId,ProjectId,Id")] StudentHasProject studentHasProject)
        {
            if (ModelState.IsValid)
            {
                _context.Add(studentHasProject);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(studentHasProject);
        }

        // GET: StudentHasProjects/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.StudentHasProject == null)
            {
                return NotFound();
            }

            var studentHasProject = await _context.StudentHasProject.FindAsync(id);
            if (studentHasProject == null)
            {
                return NotFound();
            }
            return View(studentHasProject);
        }

        // POST: StudentHasProjects/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("StudentId,ProjectId,Id")] StudentHasProject studentHasProject)
        {
            if (id != studentHasProject.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(studentHasProject);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentHasProjectExists(studentHasProject.Id))
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
            return View(studentHasProject);
        }

        // GET: StudentHasProjects/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.StudentHasProject == null)
            {
                return NotFound();
            }

            var studentHasProject = await _context.StudentHasProject
                .FirstOrDefaultAsync(m => m.Id == id);
            if (studentHasProject == null)
            {
                return NotFound();
            }

            return View(studentHasProject);
        }

        // POST: StudentHasProjects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.StudentHasProject == null)
            {
                return Problem("Entity set 'MvcProjectWebApplicationContext.StudentHasProject'  is null.");
            }
            var studentHasProject = await _context.StudentHasProject.FindAsync(id);
            if (studentHasProject != null)
            {
                _context.StudentHasProject.Remove(studentHasProject);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StudentHasProjectExists(int id)
        {
          return (_context.StudentHasProject?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
