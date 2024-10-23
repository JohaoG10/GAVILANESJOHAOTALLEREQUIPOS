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
    public class JugadorsController : Controller
    {
        private readonly tallergavilanesContext _context;

        public JugadorsController(tallergavilanesContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(int? equipoId)
        {
            ViewBag.Equipos = new SelectList(await _context.Equipoligapro.ToListAsync(), "Id", "Nombre");

            var jugadores = _context.Jugador.Include(j => j.Equipo).AsQueryable();

            if (equipoId.HasValue && equipoId.Value > 0)
            {
                jugadores = jugadores.Where(j => j.IdEquipo == equipoId.Value);
            }

            return View(await jugadores.ToListAsync());
        }

        // GET: Jugadors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jugador = await _context.Jugador
                .Include(j => j.Equipo)
                .FirstOrDefaultAsync(m => m.IdJugador == id);
            if (jugador == null)
            {
                return NotFound();
            }

            return View(jugador);
        }

        // GET: Jugadors/Create
        public IActionResult Create()
        {
            // Cambiar "Ciudad" por "Nombre"
            ViewData["IdEquipo"] = new SelectList(_context.Equipoligapro, "Id", "Nombre");
            return View();
        }

        // POST: Jugadors/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdJugador,Nombre,Posicion,Edad,IdEquipo")] Jugador jugador)
        {
            if (ModelState.IsValid)
            {
                _context.Add(jugador);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            // Cambiar "Ciudad" por "Nombre"
            ViewData["IdEquipo"] = new SelectList(_context.Equipoligapro, "Id", "Nombre", jugador.IdEquipo);
            return View(jugador);
        }

        // GET: Jugadors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jugador = await _context.Jugador.FindAsync(id);
            if (jugador == null)
            {
                return NotFound();
            }
            // Cambiar "Ciudad" por "Nombre"
            ViewData["IdEquipo"] = new SelectList(_context.Equipoligapro, "Id", "Nombre", jugador.IdEquipo);
            return View(jugador);
        }

        // POST: Jugadors/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdJugador,Nombre,Posicion,Edad,IdEquipo")] Jugador jugador)
        {
            if (id != jugador.IdJugador)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(jugador);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JugadorExists(jugador.IdJugador))
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
            // Cambiar "Ciudad" por "Nombre"
            ViewData["IdEquipo"] = new SelectList(_context.Equipoligapro, "Id", "Nombre", jugador.IdEquipo);
            return View(jugador);
        }

        // GET: Jugadors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jugador = await _context.Jugador
                .Include(j => j.Equipo)
                .FirstOrDefaultAsync(m => m.IdJugador == id);
            if (jugador == null)
            {
                return NotFound();
            }

            return View(jugador);
        }

        // POST: Jugadors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var jugador = await _context.Jugador.FindAsync(id);
            if (jugador != null)
            {
                _context.Jugador.Remove(jugador);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool JugadorExists(int id)
        {
            return _context.Jugador.Any(e => e.IdJugador == id);
        }
    }
}

