using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ObligatorioMVC.Datos;
using ObligatorioMVC.Models;

namespace ObligatorioMVC.Controllers
{
    public class ResponsableLocalsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ResponsableLocalsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ResponsableLocals
        public async Task<IActionResult> Index()
        {
            return View(await _context.ResponsableLocal.ToListAsync());
        }

        // GET: ResponsableLocals/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var responsableLocal = await _context.ResponsableLocal
                .FirstOrDefaultAsync(m => m.IdUsuario == id);
            if (responsableLocal == null)
            {
                return NotFound();
            }

            return View(responsableLocal);
        }

        // GET: ResponsableLocals/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ResponsableLocals/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Sueldo,IdUsuario,NombreUsuario,TelefonoUsuario")] ResponsableLocal responsableLocal)
        {
            if (ModelState.IsValid)
            {
                _context.Add(responsableLocal);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(responsableLocal);
        }

        // GET: ResponsableLocals/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var responsableLocal = await _context.ResponsableLocal.FindAsync(id);
            if (responsableLocal == null)
            {
                return NotFound();
            }
            return View(responsableLocal);
        }

        // POST: ResponsableLocals/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Sueldo,IdUsuario,NombreUsuario,TelefonoUsuario")] ResponsableLocal responsableLocal)
        {
            if (id != responsableLocal.IdUsuario)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(responsableLocal);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ResponsableLocalExists(responsableLocal.IdUsuario))
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
            return View(responsableLocal);
        }

        // GET: ResponsableLocals/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var responsableLocal = await _context.ResponsableLocal
                .FirstOrDefaultAsync(m => m.IdUsuario == id);
            if (responsableLocal == null)
            {
                return NotFound();
            }

            return View(responsableLocal);
        }

        // POST: ResponsableLocals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var responsableLocal = await _context.ResponsableLocal.FindAsync(id);
            if (responsableLocal != null)
            {
                _context.ResponsableLocal.Remove(responsableLocal);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ResponsableLocalExists(int id)
        {
            return _context.ResponsableLocal.Any(e => e.IdUsuario == id);
        }
    }
}
