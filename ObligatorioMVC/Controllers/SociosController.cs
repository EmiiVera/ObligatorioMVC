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
    public class SociosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SociosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Socios
        public async Task<IActionResult> Index()
        {
            var socios = await _context.Socios
                .Include(s => s.Local)
                .Include(s => s.TipoSocio)
                .Include(s => s.SocioRutinas)
                .ThenInclude(sr => sr.Rutina)
                .ToListAsync();

            return View(socios);
        }


        // GET: Socios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var socio = await _context.Socios
                .Include(s => s.Local)
                .Include(s => s.TipoSocio)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (socio == null)
            {
                return NotFound();
            }

            return View(socio);
        }

        // GET: Socios/Create
        public IActionResult Create()
        {
            ViewData["IdLocal"] = new SelectList(_context.Locales, "Id", "NombreLocal");
            ViewData["IdTipoSocio"] = new SelectList(_context.TipoSocios, "Id", "Nombre");
            ViewBag.Rutinas = new SelectList(_context.Rutinas, "Id", "DescripcionRutina");
            return View();
        }

        // POST: Socios/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdLocal,IdTipoSocio,Id,Nombre,Telefono")] Socio socio)
        {
            if (ModelState.IsValid)
            {
                _context.Add(socio);
                await _context.SaveChangesAsync();
                
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdLocal"] = new SelectList(_context.Locales, "Id", "NombreLocal", socio.IdLocal);
            ViewData["IdTipoSocio"] = new SelectList(_context.TipoSocios, "Id", "Nombre", socio.IdTipoSocio);
            return View(socio);
        }

        // GET: Socios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var socio = await _context.Socios.FindAsync(id);
            if (socio == null)
            {
                return NotFound();
            }
            ViewData["IdLocal"] = new SelectList(_context.Locales, "Id", "NombreLocal", socio.IdLocal);
            ViewData["IdTipoSocio"] = new SelectList(_context.TipoSocios, "Id", "Nombre", socio.IdTipoSocio);
            return View(socio);
        }

        // POST: Socios/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdLocal,IdTipoSocio,Id,Nombre,Telefono")] Socio socio)
        {
            if (id != socio.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(socio);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SocioExists(socio.Id))
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
            ViewData["IdLocal"] = new SelectList(_context.Locales, "Id", "NombreLocal", socio.IdLocal);
            ViewData["IdTipoSocio"] = new SelectList(_context.TipoSocios, "Id", "Nombre", socio.IdTipoSocio);
            return View(socio);
        }


        // GET: Socios/AsignarRutina/5
        public async Task<IActionResult> AsignarRutina(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var socio = await _context.Socios
                .Include(s => s.SocioRutinas)
                .ThenInclude(so => so.Rutina)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (socio == null)
            {
                return NotFound();
            }
            ViewBag.Rutinas = new SelectList(_context.Rutinas, "Id", "DescripcionRutina");
            return View(socio);
        }


        // POST: Socios/AsignarRutina
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AsignarRutina(int idSocio, int idRutina)
        {
            var socio = await _context.Socios
                .Include(r => r.SocioRutinas)
                .FirstOrDefaultAsync(s => s.Id == idSocio);
            if (socio == null)
            {
                return NotFound();
            }

            if (socio.SocioRutinas.Any(sr => sr.IdRutina == idRutina))
            {
                TempData["ErrorMessage"] = "La rutina ya está asignada al socio";
                return RedirectToAction(nameof(AsignarRutina), new { id = idSocio });
            }

            // Asignar rutina si no está asignada
            socio.SocioRutinas.Add(new SocioRutina { IdRutina = idRutina });
            try
            {
                await _context.SaveChangesAsync();
                ViewBag.Rutinas = new SelectList(_context.Rutinas, "Id", "DescripcionRutina"); // Refrescar la lista de rutinas
                return RedirectToAction(nameof(AsignarRutina), new { id = idSocio });
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "Error al asignar rutina: " + ex.Message;
                return RedirectToAction(nameof(AsignarRutina), new { id = idSocio });
            }
        }




        // POST: Socios/DesasignarRutina
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DesasignarRutina(int idSocio, int idRutina)
        {
            var socioRutina = await _context.SocioRutinas
                .FirstOrDefaultAsync(so => so.IdSocio == idSocio && so.IdRutina == idRutina);

            if (socioRutina != null)
            {
                _context.SocioRutinas.Remove(socioRutina);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(AsignarRutina), new {id= idSocio});
        }


        // GET: Socios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var socio = await _context.Socios
                .Include(s => s.Local)
                .Include(s => s.TipoSocio)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (socio == null)
            {
                return NotFound();
            }

            return View(socio);
        }

        // POST: Socios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var socio = await _context.Socios.FindAsync(id);
            if (socio != null)
            {
                _context.Socios.Remove(socio);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SocioExists(int id)
        {
            return _context.Socios.Any(e => e.Id == id);
        }
    }
}

