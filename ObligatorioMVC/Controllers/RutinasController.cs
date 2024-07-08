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
            var rutinas = await _context.Rutinas
                                        .Include(r => r.TipoRutina)
                                        .Include(r => r.RutinaEjercicios)
                                        .ThenInclude(re => re.Ejercicio)
                                        .Include(r => r.SocioRutinas)
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

            var rutina = await _context.Rutinas
                .Include(r => r.TipoRutina)
                .Include(r => r.RutinaEjercicios)
                    .ThenInclude(re => re.Ejercicio)
                .Include(r => r.SocioRutinas) // Incluir SocioRutinas
                    .ThenInclude(sr => sr.Socio)
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
            ViewData["IdTipoRutina"] = new SelectList(_context.TipoRutinas, "Id", "Nombre");
            var rutina = new Rutina();
            return View(rutina);
        }

        // POST: Rutinas/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DescripcionRutina,Calificacion,IdTipoRutina")] Rutina rutina)
        {
            if (ModelState.IsValid)
            {
                _context.Add(rutina);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            ViewData["IdTipoRutina"] = new SelectList(_context.TipoRutinas, "Id", "Nombre", rutina.IdTipoRutina);
            return View(rutina);
        }

        // GET: Rutinas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rutina = await _context.Rutinas
                .Include(r => r.RutinaEjercicios)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (rutina == null)
            {
                return NotFound();
            }

            ViewData["IdTipoRutina"] = new SelectList(_context.TipoRutinas, "Id", "Nombre", rutina.IdTipoRutina);
            ViewBag.Ejercicios = new SelectList(_context.Ejercicios, "Id", "Nombre");
            return View(rutina);
        }

        // POST: Rutinas/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DescripcionRutina,Calificacion,IdTipoRutina")] Rutina rutina, int[] ejercicioSeleccionados)
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

            ViewData["IdTipoRutina"] = new SelectList(_context.TipoRutinas, "Id", "Nombre", rutina.IdTipoRutina);
            return View(rutina);
        }

        // GET: Rutinas/AsignarEjercicio/5
        public async Task<IActionResult> AsignarEjercicio(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rutina = await _context.Rutinas
                .Include(r => r.RutinaEjercicios)
                .ThenInclude(re => re.Ejercicio)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (rutina == null)
            {
                return NotFound();
            }

            ViewBag.Ejercicios = new SelectList(_context.Ejercicios, "Id", "Nombre");
            return View(rutina);
        }

        // POST: Rutinas/AsignarEjercicio
        [HttpPost]
        public async Task<IActionResult> AsignarEjercicio(int idRutina, int idEjercicio)
        {
            var rutina = await _context.Rutinas
                .Include(r => r.RutinaEjercicios)
                .FirstOrDefaultAsync(r => r.Id == idRutina);

            if (rutina == null)
            {
                return NotFound();
            }

            // Verificar si el ejercicio ya está asignado a la rutina
            if (rutina.RutinaEjercicios.Any(re => re.IdEjercicio == idEjercicio))
            {
                TempData["ErrorMessage"] = "El ejercicio ya está asignado a esta rutina.";
                return RedirectToAction(nameof(AsignarEjercicio), new { id = idRutina });
            }

            // Asignar el ejercicio si no está asignado
            rutina.RutinaEjercicios.Add(new RutinaEjercicio { IdEjercicio = idEjercicio });

            try
            {
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(AsignarEjercicio), new { id = idRutina });
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "Error al asignar el ejercicio: " + ex.Message;
                return RedirectToAction(nameof(AsignarEjercicio), new { id = idRutina });
            }
        }


        // POST: Rutinas/DesasignarEjercicio
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DesasignarEjercicio(int idRutina, int idEjercicio)
        {
            var rutinaEjercicio = await _context.RutinaEjercicios
                .FirstOrDefaultAsync(re => re.IdRutina == idRutina && re.IdEjercicio == idEjercicio);

            if (rutinaEjercicio != null)
            {
                _context.RutinaEjercicios.Remove(rutinaEjercicio);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(AsignarEjercicio), new { id = idRutina });
        }

        // GET: Rutinas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rutina = await _context.Rutinas
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
            var rutina = await _context.Rutinas.FindAsync(id);
            if (rutina != null)
            {
                _context.Rutinas.Remove(rutina);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RutinaExists(int id)
        {
            return _context.Rutinas.Any(e => e.Id == id);
        }
    }
}