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
    public class MaquinasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MaquinasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Maquinas
        public async Task<IActionResult> Index(int? idLocal)
        {
            IQueryable<Maquina> maquinasQuery = _context.Maquinas.Include(m => m.Local).Include(m => m.TipoMaquina);

            if (idLocal.HasValue)
            {
                maquinasQuery = maquinasQuery.Where(m => m.IdLocal == idLocal);
                ViewBag.NombreLocal = _context.Locales.FirstOrDefault(l => l.Id == idLocal)?.NombreLocal;
            }

            var maquinas = await maquinasQuery.ToListAsync();

            ViewBag.Locales = await _context.Locales.ToListAsync();

            return View(maquinas);
        }



        // GET: Maquinas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var maquina = await _context.Maquinas
                .Include(m => m.Local)
                .Include(m => m.TipoMaquina)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (maquina == null)
            {
                return NotFound();
            }

            ViewBag.VidaUtilRestante = maquina.VidaUtilRestante();
            return View(maquina);
        }


        // GET: Maquinas/Create
        public IActionResult Create()
        {
            // Filtrar la lista de tipos de máquinas excluyendo "Ninguna"
            var tiposMaquina = _context.TipoMaquinas.Where(tm => tm.Nombre != "Ninguna").ToList();

            ViewData["IdLocal"] = new SelectList(_context.Locales, "Id", "NombreLocal");
            ViewData["IdTipoMaquina"] = new SelectList(tiposMaquina, "Id", "Nombre");

            return View();
        }

        // POST: Maquinas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FechaCompra,PrecioCompra,Disponibilidad,IdTipoMaquina,IdLocal,VidaUtil")] Maquina maquina)
        {
            if (ModelState.IsValid)
            {
                _context.Add(maquina);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdLocal"] = new SelectList(_context.Locales, "Id", "NombreLocal", maquina.IdLocal);
            ViewData["IdTipoMaquina"] = new SelectList(_context.TipoMaquinas, "Id", "Nombre", maquina.IdTipoMaquina);
            return View(maquina);
        }

        // GET: Maquinas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var maquina = await _context.Maquinas.FindAsync(id);
            if (maquina == null)
            {
                return NotFound();
            }
            ViewData["IdLocal"] = new SelectList(_context.Locales, "Id", "NombreLocal", maquina.IdLocal);
            ViewData["IdTipoMaquina"] = new SelectList(_context.TipoMaquinas, "Id", "Nombre", maquina.IdTipoMaquina);
            return View(maquina);
        }

        // POST: Maquinas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FechaCompra,PrecioCompra,Disponibilidad,IdTipoMaquina,IdLocal,VidaUtil")] Maquina maquina)
        {
            if (id != maquina.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(maquina);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MaquinaExists(maquina.Id))
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
            ViewData["IdLocal"] = new SelectList(_context.Locales, "Id", "NombreLocal", maquina.IdLocal);
            ViewData["IdTipoMaquina"] = new SelectList(_context.TipoMaquinas, "Id", "Nombre", maquina.IdTipoMaquina);
            return View(maquina);
        }

        // GET: Maquinas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var maquina = await _context.Maquinas
                .Include(m => m.Local)
                .Include(m => m.TipoMaquina)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (maquina == null)
            {
                return NotFound();
            }

            return View(maquina);
        }

        // POST: Maquinas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var maquina = await _context.Maquinas.FindAsync(id);
            if (maquina != null)
            {
                _context.Maquinas.Remove(maquina);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MaquinaExists(int id)
        {
            return _context.Maquinas.Any(e => e.Id == id);
        }
    }
}
