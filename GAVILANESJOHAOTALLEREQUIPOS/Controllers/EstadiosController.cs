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
    public class EstadiosController : Controller
    {
        private readonly tallergavilanesContext _context;

        public EstadiosController(tallergavilanesContext context)
        {
            _context = context;
        }

        // GET: Estadios
        public async Task<IActionResult> Index()
        {
            return View(await _context.Estadio.ToListAsync());
        }

        // GET: Estadios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estadio = await _context.Estadio
                .FirstOrDefaultAsync(m => m.IdEstadio == id);
            if (estadio == null)
            {
                return NotFound();
            }

            return View(estadio);
        }

        // GET: Estadios/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Estadios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdEstadio,Direccion,Ciudad,Capacidad,Nombre")] Estadio estadio)
        {
            if (ModelState.IsValid)
            {
                _context.Add(estadio);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(estadio);
        }

        // GET: Estadios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estadio = await _context.Estadio.FindAsync(id);
            if (estadio == null)
            {
                return NotFound();
            }
            return View(estadio);
        }

        // POST: Estadios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdEstadio,Direccion,Ciudad,Capacidad,Nombre")] Estadio estadio)
        {
            if (id != estadio.IdEstadio)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(estadio);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EstadioExists(estadio.IdEstadio))
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
            return View(estadio);
        }

        // GET: Estadios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estadio = await _context.Estadio
                .FirstOrDefaultAsync(m => m.IdEstadio == id);
            if (estadio == null)
            {
                return NotFound();
            }

            return View(estadio);
        }

        // POST: Estadios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var estadio = await _context.Estadio.FindAsync(id);
            if (estadio != null)
            {
                _context.Estadio.Remove(estadio);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EstadioExists(int id)
        {
            return _context.Estadio.Any(e => e.IdEstadio == id);
        }
    }
}
