using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GAVILANESJOHAOTALLEREQUIPOS.Models;

namespace GAVILANESJOHAOTALLEREQUIPOS.Controllers
{
    public class EquipoligaproesController : Controller
    {
        private readonly tallergavilanesContext _context;

        public EquipoligaproesController(tallergavilanesContext context)
        {
            _context = context;
        }

        // GET: Equipoligaproes
        public async Task<IActionResult> Index()
        {
            var tallergavilanesContext = _context.Equipoligapro.Include(e => e.Estadio);
            return View(await tallergavilanesContext.ToListAsync());
        }

        // GET: Equipoligaproes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var equipoligapro = await _context.Equipoligapro
                .Include(e => e.Estadio)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (equipoligapro == null)
            {
                return NotFound();
            }

            return View(equipoligapro);
        }

        // GET: Equipoligaproes/Create
        public IActionResult Create()
        {
            ViewData["IdEstadio"] = new SelectList(_context.Set<Estadio>(), "IdEstadio", "IdEstadio");
            return View();
        }

        // POST: Equipoligaproes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Ciudad,titulos,AceptaExtranjeros,IdEstadio")] Equipoligapro equipoligapro)
        {
            if (ModelState.IsValid)
            {
                _context.Add(equipoligapro);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdEstadio"] = new SelectList(_context.Set<Estadio>(), "IdEstadio", "IdEstadio", equipoligapro.IdEstadio);
            return View(equipoligapro);
        }

        // GET: Equipoligaproes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var equipoligapro = await _context.Equipoligapro.FindAsync(id);
            if (equipoligapro == null)
            {
                return NotFound();
            }
            ViewData["IdEstadio"] = new SelectList(_context.Set<Estadio>(), "IdEstadio", "IdEstadio", equipoligapro.IdEstadio);
            return View(equipoligapro);
        }

        // POST: Equipoligaproes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Ciudad,titulos,AceptaExtranjeros,IdEstadio")] Equipoligapro equipoligapro)
        {
            if (id != equipoligapro.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(equipoligapro);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EquipoligaproExists(equipoligapro.Id))
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
            ViewData["IdEstadio"] = new SelectList(_context.Set<Estadio>(), "IdEstadio", "IdEstadio", equipoligapro.IdEstadio);
            return View(equipoligapro);
        }

        // GET: Equipoligaproes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var equipoligapro = await _context.Equipoligapro
                .Include(e => e.Estadio)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (equipoligapro == null)
            {
                return NotFound();
            }

            return View(equipoligapro);
        }

        // POST: Equipoligaproes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var equipoligapro = await _context.Equipoligapro.FindAsync(id);
            if (equipoligapro != null)
            {
                _context.Equipoligapro.Remove(equipoligapro);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EquipoligaproExists(int id)
        {
            return _context.Equipoligapro.Any(e => e.Id == id);
        }
    }
}
