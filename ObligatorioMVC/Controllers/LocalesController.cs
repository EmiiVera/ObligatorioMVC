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
    public class LocalesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LocalesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Locales
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Locales.Include(l => l.ResponsableLocal);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Lista de máquinas
        public async Task<IActionResult> ListaDeMaquinas(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //Seleccionar máquinas por ID de local
            var maquinas = _context.Maquina.Include(m => m.TipoMaquina)
                .Include(m => m.Locales).Where(m => m.IdLocal == id).ToList();


            if (maquinas == null)
            {
                return NotFound();
            }

            return View(maquinas); 
        }

        // GET: Locales/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var locales = await _context.Locales
                .Include(l => l.ResponsableLocal)
                .Include(l => l.Maquina).ThenInclude(l => l.TipoMaquina)
                .FirstOrDefaultAsync(m => m.IdLocal == id);

            if (locales == null)
            {
                return NotFound();
            }

            var maquinas = _context.Maquina.Include(m => m.TipoMaquina)
               .Include(m => m.Locales).Where(m => m.IdLocal == id).ToList();

            ViewData["Maquinas"] = new SelectList(maquinas, "IdMaquina");
            ViewBag.TipoMaquina = new SelectList(_context.TipoMaquina, "NombreTipoMaquina");

            return View(locales);
        }

        // GET: Locales/Create
        public IActionResult Create()
        {

            //Cargar Responsables disponibles
            var responsableLocal = _context.ResponsableLocal.ToList();
            var existeResponsable = _context.Locales.Include(l => l.ResponsableLocal).ToList();
            foreach (var l in existeResponsable)
            {
                responsableLocal.Remove(l.ResponsableLocal);
            }

            ViewData["IdResponsableLocal"] = new SelectList(responsableLocal, "IdUsuario", "NombreUsuario");
            
            return View();
        }

        // POST: Locales/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdLocal,NombreLocal,Ciudad,Direccion,TelefonoLocal,IdResponsableLocal")] Locales locales)
        {
            
            if (ModelState.IsValid)
            {
                _context.Add(locales);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdResponsableLocal"] = new SelectList(_context.ResponsableLocal, "IdUsuario", "NombreUsuario", locales.IdResponsableLocal);
            return View(locales);
        }

        // GET: Locales/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var locales = await _context.Locales.FindAsync(id);
            if (locales == null)
            {
                return NotFound();
            }

            //Cargar Responsables disponibles
            var responsableLocal = _context.ResponsableLocal.ToList();
            var existeResponsable = _context.Locales.Include(l => l.ResponsableLocal).ToList();
            foreach (var l in existeResponsable)
            {
                responsableLocal.Remove(l.ResponsableLocal);
            }

            responsableLocal.Add(await _context.ResponsableLocal.FindAsync(locales.IdResponsableLocal));

            ViewData["IdResponsableLocal"] = new SelectList(responsableLocal, "IdUsuario", "NombreUsuario", locales.IdResponsableLocal);
            return View(locales);
        }

        // POST: Locales/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdLocal,NombreLocal,Ciudad,Direccion,TelefonoLocal,IdResponsableLocal")] Locales locales)
        {
            if (id != locales.IdLocal)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(locales);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LocalesExists(locales.IdLocal))
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
            ViewData["IdResponsableLocal"] = new SelectList(_context.ResponsableLocal, "IdUsuario", "NombreUsuario", locales.IdResponsableLocal);
            return View(locales);
        }

        // GET: Locales/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var locales = await _context.Locales
                .Include(l => l.ResponsableLocal)
                .FirstOrDefaultAsync(m => m.IdLocal == id);
            if (locales == null)
            {
                return NotFound();
            }

            return View(locales);
        }

        // POST: Locales/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var locales = await _context.Locales.FindAsync(id);
            if (locales != null)
            {
                _context.Locales.Remove(locales);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LocalesExists(int id)
        {
            return _context.Locales.Any(e => e.IdLocal == id);
        }
    }
}
