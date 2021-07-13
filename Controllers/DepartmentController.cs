using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SE141048_VoQuocHuy_PE.Identity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SE141048_VoQuocHuy_PE.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly DataContext _context;
        private IWebHostEnvironment _webHostEnvironment;
        public DepartmentController(DataContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        // GET: DepartmentController
        public async Task<IActionResult> Index()
        {
            return View(await _context.Deparments.ToListAsync());
        }

        // GET: DepartmentController/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var department = await _context.Deparments
                .FirstOrDefaultAsync(m => m.depID == id);
            if (department == null)
            {
                return NotFound();
            }

            return View(department);
        }

        // GET: DepartmentController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DepartmentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Department department, IFormFile Photo)
        {
            if (Photo == null || Photo.Length == 0)
            {
                return Content("Photo not choose");
            }
            else
            {
                var path = Path.Combine(this._webHostEnvironment.WebRootPath, "images", Photo.FileName);
                var stream = new FileStream(path, FileMode.Create);
                Photo.CopyToAsync(stream);
                department.photo = Photo.FileName;
                _context.Deparments.Add(department);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
/*            if (ModelState.IsValid)
            {
                _context.Add(department);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }*/
/*            return View(department);*/
        }

        // GET: DepartmentController/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var department = await _context.Deparments
                .FirstOrDefaultAsync(m => m.depID == id);
            if (department == null)
            {
                return NotFound();
            }
            return View(department);
        }

        // POST: DepartmentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("depID,depName,age,salary,email,birthday,photo,married,address,professorID")] Department department, IFormFile Photo)
        {
            if (id != department.depID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if(Photo!= null || Photo.Length != 0)
                    {
                        var path = Path.Combine(this._webHostEnvironment.WebRootPath, "images", Photo.FileName);
                        var stream = new FileStream(path, FileMode.Create);
                        Photo.CopyToAsync(stream);
                        department.photo = Photo.FileName;
                    }
                    _context.Update(department);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DepartmentExists(department.depID))
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
            return View(department);
        }

        // GET: DepartmentController/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var department = await _context.Deparments
                .FirstOrDefaultAsync(m => m.depID == id);
            if (department == null)
            {
                return NotFound();
            }

            return View(department);
        }

        // POST: DepartmentController/Delete/5
        [HttpPost, ActionName("Delete")]
/*        [ValidateAntiForgeryToken]*/
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var department = await _context.Deparments.FindAsync(id);
            _context.Deparments.Remove(department);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        private bool DepartmentExists(int id)
        {
            return _context.Deparments.Any(e => e.depID == id);
        }
    }
}
