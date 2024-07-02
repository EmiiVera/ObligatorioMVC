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
            var rutinas = await _context.Rutina
                                        .Include(r => r.TipoRutina)
                                        .Include(r => r.RutinaEjercicios)
                                            .ThenInclude(re => re.Ejercicio)
                                        .ToListAsync();

            return View(rutinas);
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
                .FirstOrDefaultAsync(m => m.Id == id);
            if (rutina == null)
            {
                return NotFound();
            }

            return View(rutina);
        }

        // GET: Rutinas/Create
        public IActionResult Create()
        {
            ViewData["IdTipoRutina"] = new SelectList(_context.TipoRutina, "Id", "Nombre");
            ViewData["Ejercicios"] = new MultiSelectList(_context.Ejercicio, "Id", "Nombre");
            return View();
        }


        // POST: Rutinas/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DescripcionRutina,Calificacion,IdTipoRutina,EjercicioSeleccionados")] Rutina rutina)
        {
            if (ModelState.IsValid)
            {
                _context.Add(rutina);
                await _context.SaveChangesAsync();

                if (rutina.EjercicioSeleccionados != null && rutina.EjercicioSeleccionados.Any())
                {
                    foreach (var ejercicioId in rutina.EjercicioSeleccionados)
                    {
                        var rutinaEjercicio = new RutinaEjercicio
                        {
                            IdRutina = rutina.Id,
                            IdEjercicio = ejercicioId
                        };
                        _context.RutinaEjercicios.Add(rutinaEjercicio);
                    }
                    await _context.SaveChangesAsync();
                }

                return RedirectToAction(nameof(Index));
            }

            ViewData["IdTipoRutina"] = new SelectList(_context.TipoRutina, "Id", "Nombre", rutina.IdTipoRutina);
            ViewData["Ejercicios"] = new MultiSelectList(_context.Ejercicio, "Id", "Nombre", rutina.EjercicioSeleccionados);
            return View(rutina);
        }

        // GET: Rutinas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rutina = await _context.Rutina.Include(r => r.RutinaEjercicios).FirstOrDefaultAsync(m => m.Id == id);
            if (rutina == null)
            {
                return NotFound();
            }

            rutina.EjercicioSeleccionados = rutina.RutinaEjercicios.Select(re => re.IdEjercicio).ToList();
            ViewData["IdTipoRutina"] = new SelectList(_context.TipoRutina, "Id", "Nombre", rutina.IdTipoRutina);
            ViewData["Ejercicios"] = new MultiSelectList(_context.Ejercicio, "Id", "Nombre", rutina.EjercicioSeleccionados);
            return View(rutina);
        }

        // POST: Rutinas/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DescripcionRutina,Calificacion,IdTipoRutina,EjercicioSeleccionados")] Rutina rutina)
        {
            if (id != rutina.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rutina);
                    await _context.SaveChangesAsync();

                    var existingEjercicios = _context.RutinaEjercicios.Where(re => re.IdRutina == rutina.Id).ToList();
                    _context.RutinaEjercicios.RemoveRange(existingEjercicios);

                    foreach (var ejercicioId in rutina.EjercicioSeleccionados)
                    {
                        var rutinaEjercicio = new RutinaEjercicio
                        {
                            IdRutina = rutina.Id,
                            IdEjercicio = ejercicioId
                        };
                        _context.RutinaEjercicios.Add(rutinaEjercicio);
                    }

                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RutinaExists(rutina.Id))
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
            ViewData["IdTipoRutina"] = new SelectList(_context.TipoRutina, "Id", "Nombre", rutina.IdTipoRutina);
            ViewData["Ejercicios"] = new MultiSelectList(_context.Ejercicio, "Id", "Nombre", rutina.EjercicioSeleccionados);
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
                .FirstOrDefaultAsync(m => m.Id == id);
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
            return _context.Rutina.Any(e => e.Id == id);
        }
    }
}
