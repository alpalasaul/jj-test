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
    public class FacultadJjsController : Controller
    {
        private readonly BibliotecaJjContext _context;

        public FacultadJjsController(BibliotecaJjContext context)
        {
            _context = context;
        }

        // GET: FacultadJjs
        public async Task<IActionResult> Index()
        {
              return View(await _context.FacultadJjs.ToListAsync());
        }

        // GET: FacultadJjs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.FacultadJjs == null)
            {
                return NotFound();
            }

            var facultadJj = await _context.FacultadJjs
                .FirstOrDefaultAsync(m => m.IdFacultad == id);
            if (facultadJj == null)
            {
                return NotFound();
            }

            return View(facultadJj);
        }

        // GET: FacultadJjs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: FacultadJjs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdFacultad,Nombre,Estado")] FacultadJj facultadJj)
        {
            if (ModelState.IsValid)
            {
                _context.Add(facultadJj);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(facultadJj);
        }

        // GET: FacultadJjs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.FacultadJjs == null)
            {
                return NotFound();
            }

            var facultadJj = await _context.FacultadJjs.FindAsync(id);
            if (facultadJj == null)
            {
                return NotFound();
            }
            return View(facultadJj);
        }

        // POST: FacultadJjs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdFacultad,Nombre,Estado")] FacultadJj facultadJj)
        {
            if (id != facultadJj.IdFacultad)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(facultadJj);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FacultadJjExists(facultadJj.IdFacultad))
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
            return View(facultadJj);
        }

        // GET: FacultadJjs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.FacultadJjs == null)
            {
                return NotFound();
            }

            var facultadJj = await _context.FacultadJjs
                .FirstOrDefaultAsync(m => m.IdFacultad == id);
            if (facultadJj == null)
            {
                return NotFound();
            }

            return View(facultadJj);
        }

        // POST: FacultadJjs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.FacultadJjs == null)
            {
                return Problem("Entity set 'BibliotecaJjContext.FacultadJjs'  is null.");
            }
            var facultadJj = await _context.FacultadJjs.FindAsync(id);
            if (facultadJj != null)
            {
                _context.FacultadJjs.Remove(facultadJj);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FacultadJjExists(int id)
        {
          return _context.FacultadJjs.Any(e => e.IdFacultad == id);
        }
    }
}
