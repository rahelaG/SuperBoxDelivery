using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Controllers
{
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AdminController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult AddAdmin(string usernameOrEmail)
        {
            var user = _context.Users
                .FirstOrDefault(u => u.UserName == usernameOrEmail || u.Email == usernameOrEmail);

            if (user != null)
            {
                user.IsAdmin = true;
                _context.SaveChanges(); // Salvează modificările în baza de date
                TempData["Message"] = "User promoted to admin!";
                return RedirectToAction("AdminHomePage", "Account"); // Redirecționează la acțiunea AdminHomePage din AccountController
                // Înapoi pe pagina de admin
            }
            else
            {
                TempData["ErrorMessage"] = "User not found.";
                return RedirectToAction("AdminHomePage", "Account"); // Redirecționează la acțiunea AdminHomePage din AccountController

            }
        }
        [Authorize(Roles = "Admin")]
        public IActionResult AdminHomePage()
        {
            return View();
        }
    }
}
