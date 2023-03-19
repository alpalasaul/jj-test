using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Biblioteca.Models;
using Microsoft.AspNetCore.Authorization;

namespace Biblioteca.Controllers
{

    [Authorize]
    public class LibroesController : Controller
    {
        private readonly BibliotecaJjContext _context;

        public LibroesController(BibliotecaJjContext context)
        {
            _context = context;
        }

        // GET: Libroes
        public async Task<IActionResult> Index(string buscar)
        {
           var libros = from Libro in _context.Libros select Libro;
            var bibliotecaContext = _context.Libros.Include(l => l.IdAutorNavigation).Include(l => l.IdCategoriaEdadNavigation).Include(l => l.IdEstadoNavigation).Include(l => l.IdTipoLibroNavigation).Include(l => l.MateriaNavigation);

            if (!String.IsNullOrEmpty(buscar))
            {
                libros = libros.Where(s => s.Titulo!.Contains(buscar));
            }
            return View(await libros.ToListAsync());
        }

        // GET: Libroes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Libros == null)
            {
                return NotFound();
            }

            var libro = await _context.Libros
                .Include(l => l.IdAutorNavigation)
                .Include(l => l.IdCategoriaEdadNavigation)
                .Include(l => l.IdEstadoNavigation)
                .Include(l => l.IdTipoLibroNavigation)
                .Include(l => l.MateriaNavigation)
                .FirstOrDefaultAsync(m => m.IdLibro == id);
            if (libro == null)
            {
                return NotFound();
            }

            return View(libro);
        }

        // GET: Libroes/Create
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
                ViewData["IdAutor"] = new SelectList(_context.Autors, "IdAutor", "NombreAutor");
                ViewData["IdCategoriaEdad"] = new SelectList(_context.CategoriaEdads, "IdCategoriaEdad", "NombreCategoria");
                ViewData["IdEstado"] = new SelectList(_context.Estados, "IdEstado", "NombreEstado");
                ViewData["IdTipoLibro"] = new SelectList(_context.TipoLibros, "IdTipoLibro", "NombreTipoLibro");
                ViewData["Materia"] = new SelectList(_context.Materia, "IdMateria", "NombreMateria");
                return View();
        
            
        }

        // POST: Libroes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create([Bind("IdLibro,IdAutor,IdEstado,IdTipoLibro,IdCategoriaEdad,Titulo,Materia")] Libro libro)
        {
            if (ModelState.IsValid)
            {
                _context.Add(libro);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdAutor"] = new SelectList(_context.Autors, "IdAutor", "IdAutor", libro.IdAutor);
            ViewData["IdCategoriaEdad"] = new SelectList(_context.CategoriaEdads, "IdCategoriaEdad", "IdCategoriaEdad", libro.IdCategoriaEdad);
            ViewData["IdEstado"] = new SelectList(_context.Estados, "IdEstado", "IdEstado", libro.IdEstado);
            ViewData["IdTipoLibro"] = new SelectList(_context.TipoLibros, "IdTipoLibro", "IdTipoLibro", libro.IdTipoLibro);
            ViewData["Materia"] = new SelectList(_context.Materia, "IdMateria", "IdMateria", libro.Materia);
            return View(libro);
        }

        // GET: Libroes/Edit/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Libros == null)
            {
                return NotFound();
            }

            var libro = await _context.Libros.FindAsync(id);
            if (libro == null)
            {
                return NotFound();
            }
            ViewData["IdAutor"] = new SelectList(_context.Autors, "IdAutor", "NombreAutor", libro.IdAutor);
            ViewData["IdCategoriaEdad"] = new SelectList(_context.CategoriaEdads, "IdCategoriaEdad", "NombreCategoria", libro.IdCategoriaEdad);
            ViewData["IdEstado"] = new SelectList(_context.Estados, "IdEstado", "NombreEstado", libro.IdEstado);
            ViewData["IdTipoLibro"] = new SelectList(_context.TipoLibros, "IdTipoLibro", "NombreTipoLibro", libro.IdTipoLibro);
            ViewData["Materia"] = new SelectList(_context.Materia, "IdMateria", "NombreMateria", libro.Materia);
            return View(libro);
        }


        // POST: Libroes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int id, [Bind("IdLibro,IdAutor,IdEstado,IdTipoLibro,IdCategoriaEdad,Titulo,Materia")] Libro libro)
        {
            if (id != libro.IdLibro)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(libro);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LibroExists(libro.IdLibro))
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
            ViewData["IdAutor"] = new SelectList(_context.Autors, "IdAutor", "IdAutor", libro.IdAutor);
            ViewData["IdCategoriaEdad"] = new SelectList(_context.CategoriaEdads, "IdCategoriaEdad", "IdCategoriaEdad", libro.IdCategoriaEdad);
            ViewData["IdEstado"] = new SelectList(_context.Estados, "IdEstado", "IdEstado", libro.IdEstado);
            ViewData["IdTipoLibro"] = new SelectList(_context.TipoLibros, "IdTipoLibro", "IdTipoLibro", libro.IdTipoLibro);
            ViewData["Materia"] = new SelectList(_context.Materia, "IdMateria", "IdMateria", libro.Materia);
            return View(libro);
        }

        // GET: Libroes/Delete/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Libros == null)
            {
                return NotFound();
            }

            var libro = await _context.Libros
                .Include(l => l.IdAutorNavigation)
                .Include(l => l.IdCategoriaEdadNavigation)
                .Include(l => l.IdEstadoNavigation)
                .Include(l => l.IdTipoLibroNavigation)
                .Include(l => l.MateriaNavigation)
                .FirstOrDefaultAsync(m => m.IdLibro == id);
            if (libro == null)
            {
                return NotFound();
            }

            return View(libro);
        }

        // POST: Libroes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Libros == null)
            {
                return Problem("Entity set 'BibliotecaContext.Libros'  is null.");
            }
            var libro = await _context.Libros.FindAsync(id);
            if (libro != null)
            {
                _context.Libros.Remove(libro);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LibroExists(int id)
        {
          return _context.Libros.Any(e => e.IdLibro == id);
        }
    }
}
