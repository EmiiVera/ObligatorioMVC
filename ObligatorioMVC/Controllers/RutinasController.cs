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
    public class RutinasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RutinasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Rutinas
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Rutina.Include(r => r.TipoRutina);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Rutinas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rutina = await _context.Rutina
                .Include(r => r.TipoRutina)
                .FirstOrDefaultAsync(m => m.IdRutina == id);
            if (rutina == null)
            {
                return NotFound();
            }

            return View(rutina);
        }

        // GET: Rutinas/Create
        public IActionResult Create()
        {
            ViewData["tipoRutina"] = new SelectList(_context.TipoRutina, "IdTipoRutina", "NombreTipoRutina");
            return View();
        }

        // POST: Rutinas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdRutina,DescripcionRutina,Calificacion,tipoRutina")] Rutina rutina)
        {
            if (ModelState.IsValid)
            {
                _context.Add(rutina);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["tipoRutina"] = new SelectList(_context.TipoRutina, "IdTipoRutina", "NombreTipoRutina", rutina.tipoRutina);
            return View(rutina);
        }

        // GET: Rutinas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rutina = await _context.Rutina.FindAsync(id);
            if (rutina == null)
            {
                return NotFound();
            }
            ViewData["tipoRutina"] = new SelectList(_context.TipoRutina, "IdTipoRutina", "NombreTipoRutina", rutina.tipoRutina);
            return View(rutina);
        }

        // POST: Rutinas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdRutina,DescripcionRutina,Calificacion,tipoRutina")] Rutina rutina)
        {
            if (id != rutina.IdRutina)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rutina);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RutinaExists(rutina.IdRutina))
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
            ViewData["tipoRutina"] = new SelectList(_context.TipoRutina, "IdTipoRutina", "NombreTipoRutina", rutina.tipoRutina);
            return View(rutina);
        }

        // GET: Rutinas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rutina = await _context.Rutina
                .Include(r => r.TipoRutina)
                .FirstOrDefaultAsync(m => m.IdRutina == id);
            if (rutina == null)
            {
                return NotFound();
            }

            return View(rutina);
        }

        // POST: Rutinas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var rutina = await _context.Rutina.FindAsync(id);
            if (rutina != null)
            {
                _context.Rutina.Remove(rutina);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RutinaExists(int id)
        {
            return _context.Rutina.Any(e => e.IdRutina == id);
        }
    }
}
