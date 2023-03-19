using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Biblioteca.Models;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace Biblioteca.Controllers
{
    [Authorize(Roles = "Admin")]
    public class UsersController : Controller
    {
        private readonly BibliotecaJjContext _context;

        public UsersController(BibliotecaJjContext context)
        {
            _context = context;
        }

        [HttpPost]
        public ActionResult Add(Models.User model) { 
            if (!ModelState.IsValid)
            {
                return View(model);

            }
            return Content("Se guardo");
        }

        // GET: Users
        public async Task<IActionResult> Index()
        {
            var bibliotecaContext = _context.Users.Include(u => u.IdEstadoCivilNavigation).Include(u => u.IdGeneroNavigation).Include(u => u.IdUsersRolNavigation);
            return View(await bibliotecaContext.ToListAsync());
        }

        // GET: Users/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Users == null)
            {
                return NotFound();
            }

            var user = await _context.Users
                .Include(u => u.IdEstadoCivilNavigation)
                .Include(u => u.IdGeneroNavigation)
                .Include(u => u.IdUsersRolNavigation)
                .FirstOrDefaultAsync(m => m.IdUsuario == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // GET: Users/Create
        public IActionResult Create()
        {
            ViewData["IdEstadoCivil"] = new SelectList(_context.EstadoCivils, "IdEstadoCivil", "NombreEstadoCivil");
            ViewData["IdGenero"] = new SelectList(_context.Generos, "IdGenero", "NombreGenero");
            ViewData["IdUsersRol"] = new SelectList(_context.UsersRols, "IdUsersRol", "NombreUsers");
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdUsuario,IdGenero,IdEstadoCivil,IdUsersRol,NombreUsuario,ApellidoUsuario,CedulaUsuario,UserName,FechaNacimiento,Direccion,UserPassword")] User user)
        {
            if(user == null)
            {
                try
                {
                    if (ModelState.IsValid)
                    {
                        _context.Add(user);
                        await _context.SaveChangesAsync();
                        return RedirectToAction(nameof(Index));
                    }
                    ViewData["IdEstadoCivil"] = new SelectList(_context.EstadoCivils, "IdEstadoCivil", "IdEstadoCivil", user.IdEstadoCivil);
                    ViewData["IdGenero"] = new SelectList(_context.Generos, "IdGenero", "IdGenero", user.IdGenero);
                    ViewData["IdUsersRol"] = new SelectList(_context.UsersRols, "IdUsersRol", "IdUsersRol", user.IdUsersRol);
                    return View(user);

                }
                catch (Exception ex)
                {
                    ViewData["Mensaje"] = "Cedula ya registrada";
                }
            }
            ViewData["Mensaje"] = "Cedula ya registrada";
            return RedirectToAction("Create", user);
            
        }

        // GET: Users/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Users == null)
            {
                return NotFound();
            }

            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            ViewData["IdEstadoCivil"] = new SelectList(_context.EstadoCivils, "IdEstadoCivil", "NombreEstadoCivil", user.IdEstadoCivil);
            ViewData["IdGenero"] = new SelectList(_context.Generos, "IdGenero", "NombreGenero", user.IdGenero);
            ViewData["IdUsersRol"] = new SelectList(_context.UsersRols, "IdUsersRol", "NombreUsers", user.IdUsersRol);
            return View(user);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdUsuario,IdGenero,IdEstadoCivil,IdUsersRol,NombreUsuario,ApellidoUsuario,CedulaUsuario,UserName,FechaNacimiento,Direccion,UserPassword")] User user)
        {
            if (id != user.IdUsuario)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(user);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserExists(user.IdUsuario))
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
            ViewData["IdEstadoCivil"] = new SelectList(_context.EstadoCivils, "IdEstadoCivil", "IdEstadoCivil", user.IdEstadoCivil);
            ViewData["IdGenero"] = new SelectList(_context.Generos, "IdGenero", "IdGenero", user.IdGenero);
            ViewData["IdUsersRol"] = new SelectList(_context.UsersRols, "IdUsersRol", "IdUsersRol", user.IdUsersRol);
            return View(user);
        }

        // GET: Users/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Users == null)
            {
                return NotFound();
            }

            var user = await _context.Users
                .Include(u => u.IdEstadoCivilNavigation)
                .Include(u => u.IdGeneroNavigation)
                .Include(u => u.IdUsersRolNavigation)
                .FirstOrDefaultAsync(m => m.IdUsuario == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Users == null)
            {
                return Problem("Entity set 'BibliotecaContext.Users'  is null.");
            }
            var user = await _context.Users.FindAsync(id);
            if (user != null)
            {
                _context.Users.Remove(user);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserExists(int id)
        {
          return _context.Users.Any(e => e.IdUsuario == id);
        }
    }
}
