using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using Biblioteca.Models;

namespace Test2.Controllers
{
    public class AccessController : Controller
    {
        private readonly BibliotecaJjContext _context;

        public AccessController(BibliotecaJjContext context)
        {
            _context = context;
        }
        public IActionResult Login()
        {
            
                ClaimsPrincipal claimUser = HttpContext.User;
                if (claimUser.Identity.IsAuthenticated)
                 return RedirectToAction("Index", "Home");

            return View();
        }
        [HttpPost]
        public User Validate(string email, string clave)
        {
            try
            {
                User user;
                var list = from users in _context.Users
                            .Include(a => a.IdUsersRolNavigation)
                            .Where(a => a.UserName.Equals(email) && a.UserPassword.Equals(clave))
                           select users;
                user = list.FirstOrDefault();
                return user;
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        [HttpPost]
        public async Task<IActionResult> Login(User user)
        {
            user = Validate(user.UserName, user.UserPassword);
            if(user == null)
            {
                ViewData["ValidateMessage"] = "Datos erroneos";
                return View();
            }
            else
            {
                List<Claim> claims = new List<Claim>()
                {
                    new Claim(ClaimTypes.NameIdentifier, user.UserName),
                    new Claim(ClaimTypes.Role, user.IdUsersRolNavigation.NombreUsers)
                };

                ClaimsIdentity claimsIdentity= new ClaimsIdentity(claims,
                    CookieAuthenticationDefaults.AuthenticationScheme);

                AuthenticationProperties authenticationProperties = new AuthenticationProperties()
                {
                    AllowRefresh= true,
                   
                };

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity), authenticationProperties);
                return RedirectToAction("Index", "Home");
            }

        }
        public IActionResult SinPermiso ()
        {
            return View();
        }

    }
}
