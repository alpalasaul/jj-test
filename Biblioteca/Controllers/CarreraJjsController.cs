using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Biblioteca.Models;

namespace Biblioteca.Controllers
{
    public class CarreraJjsController : Controller
    {
        private readonly BibliotecaJjContext _context;

        public CarreraJjsController(BibliotecaJjContext context)
        {
            _context = context;
        }

        // GET: CarreraJjs
        public async Task<IActionResult> Index()
        {
            var bibliotecaJjContext = _context.CarreraJjs.Include(c => c.IdFacultadNavigation);
            return View(await bibliotecaJjContext.ToListAsync());
        }

        // GET: CarreraJjs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.CarreraJjs == null)
            {
                return NotFound();
            }

            var carreraJj = await _context.CarreraJjs
                .Include(c => c.IdFacultadNavigation)
                .FirstOrDefaultAsync(m => m.IdCarrera == id);
            if (carreraJj == null)
            {
                return NotFound();
            }

            return View(carreraJj);
        }

        // GET: CarreraJjs/Create
        public IActionResult Create()
        {
            ViewData["IdFacultad"] = new SelectList(_context.FacultadJjs, "IdFacultad", "IdFacultad");
            return View();
        }

        // POST: CarreraJjs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdCarrera,IdFacultad,Nombre,Estado")] CarreraJj carreraJj)
        {
            if (ModelState.IsValid)
            {
                _context.Add(carreraJj);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdFacultad"] = new SelectList(_context.FacultadJjs, "IdFacultad", "IdFacultad", carreraJj.IdFacultad);
            return View(carreraJj);
        }

        // GET: CarreraJjs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.CarreraJjs == null)
            {
                return NotFound();
            }

            var carreraJj = await _context.CarreraJjs.FindAsync(id);
            if (carreraJj == null)
            {
                return NotFound();
            }
            ViewData["IdFacultad"] = new SelectList(_context.FacultadJjs, "IdFacultad", "IdFacultad", carreraJj.IdFacultad);
            return View(carreraJj);
        }

        // POST: CarreraJjs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdCarrera,IdFacultad,Nombre,Estado")] CarreraJj carreraJj)
        {
            if (id != carreraJj.IdCarrera)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(carreraJj);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CarreraJjExists(carreraJj.IdCarrera))
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
            ViewData["IdFacultad"] = new SelectList(_context.FacultadJjs, "IdFacultad", "IdFacultad", carreraJj.IdFacultad);
            return View(carreraJj);
        }

        // GET: CarreraJjs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.CarreraJjs == null)
            {
                return NotFound();
            }

            var carreraJj = await _context.CarreraJjs
                .Include(c => c.IdFacultadNavigation)
                .FirstOrDefaultAsync(m => m.IdCarrera == id);
            if (carreraJj == null)
            {
                return NotFound();
            }

            return View(carreraJj);
        }

        // POST: CarreraJjs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.CarreraJjs == null)
            {
                return Problem("Entity set 'BibliotecaJjContext.CarreraJjs'  is null.");
            }
            var carreraJj = await _context.CarreraJjs.FindAsync(id);
            if (carreraJj != null)
            {
                _context.CarreraJjs.Remove(carreraJj);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CarreraJjExists(int id)
        {
          return _context.CarreraJjs.Any(e => e.IdCarrera == id);
        }
    }
}
