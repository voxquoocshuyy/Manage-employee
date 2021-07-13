using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SE141048_VoQuocHuy_PE.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SE141048_VoQuocHuy_PE.Controllers
{
    public class ProfessorController : Controller
    {
        private readonly DataContext _context;

        public ProfessorController(DataContext context)
        {
            _context = context;
        }

        // GET: ProfessorController
        public async Task<IActionResult> Index()
        {
            return View(await _context.Professors.ToListAsync());
        }

        // GET: ProfessorController/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var professor = await _context.Professors
                .FirstOrDefaultAsync(m => m.proID == id);
            if (professor == null)
            {
                return NotFound();
            }

            return View(professor);
        }

        // GET: ProfessorController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProfessorController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("proID,proName,employee,location")] Professor professor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(professor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(professor);
        }

        // GET: ProfessorController/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var professor = await _context.Professors
                .FirstOrDefaultAsync(m => m.proID == id);
            if (professor == null)
            {
                return NotFound();
            }
            return View(professor);
        }

        // POST: ProfessorController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("proID,proName,employee,location")] Professor professor)
        {
            if (id != professor.proID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(professor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProfessorExists(professor.proID))
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
            return View(professor);
        }

        // GET: ProfessorController/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var professor = await _context.Professors
                .FirstOrDefaultAsync(m => m.proID == id);
            if (professor == null)
            {
                return NotFound();
            }

            return View(professor);
        }

        // POST: ProfessorController/Delete/5
        [HttpPost, ActionName("Delete")]
        /*        [ValidateAntiForgeryToken]*/
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var professor = await _context.Professors.FindAsync(id);
            _context.Professors.Remove(professor);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProfessorExists(int id)
        {
            return _context.Professors.Any(e => e.proID == id);
        }
    }
}
