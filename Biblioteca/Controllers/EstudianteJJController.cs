using Biblioteca.Excepcion;
using Biblioteca.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca.Controllers
{
    public class EstudianteJJController : Controller
    {

        private readonly BibliotecaJjContext _context;

        public EstudianteJJController(BibliotecaJjContext context)
        {
            _context = context;
        }

        public async  Task<ActionResult> EstudianteJJ()
        {           
            return View(await _context.EstudianteJjs.ToListAsync());
        }

        public ActionResult Crear()
        {
            List<SelectListItem> lst = new List<SelectListItem>();
            lst = (from p in _context.FacultadJjs
                   select new SelectListItem
                   {
                       Value = p.IdFacultad.ToString(),
                       Text = p.Nombre
                   }).ToList();

            ViewData["Facultad"]= new SelectList(_context.FacultadJjs, "IdFacultad", "Nombre");
            return View();
        }

        [HttpPost]
        public ActionResult Guardar(EstudianteJj proveedor)
        {
            try
            {
                if (proveedor.Cedula.Length > 10)
                    throw new CedException("Cantidad superior a 10");
                _context.Add(proveedor);

                return RedirectToAction("EstudianteJj");
            }
            catch(CedException re)
            {
                ViewData["CedEx"] = re.Message;
                List<SelectListItem> lst = new List<SelectListItem>();
                lst = (from p in _context.FacultadJjs
                       select new SelectListItem
                       {
                           Value = p.IdFacultad.ToString(),
                           Text = p.Nombre
                       }).ToList();

                ViewData["Facultad"] = new SelectList(_context.FacultadJjs, "IdFacultad", "Nombre");
                return View("Crear");
            }
        }

        public ActionResult Editar(int id)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Salvar(int id, EstudianteJj estudianteJj)
        {
            try
            {
                _context.Update(estudianteJj);

                return RedirectToAction(nameof(estudianteJj));
            }
            catch
            {
                return View("EstudianteJj");
            }
        }









        [HttpGet]
        public JsonResult Cantones(int id)
        {
            List<JsonElementIntKey> lst = new List<JsonElementIntKey>();
            lst = (from e in _context.CarreraJjs
                   where e.IdFacultadNavigation.IdFacultad == id
                   select new JsonElementIntKey
                   {
                       Value = e.IdCarrera,
                       Text = e.Nombre
                   }).ToList();
            return Json(lst);
        }

        public class JsonElementIntKey
        {
            public int Value { get; set; }
            public string Text { get; set; }
        }





    }









    



}
