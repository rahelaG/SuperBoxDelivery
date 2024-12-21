using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Controllers
{
    public class SuperBoxController : Controller
    {
        private readonly ApplicationDbContext _context;

        // Constructorul controller-ului pentru a injecța contextul bazei de date
        public SuperBoxController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: SuperBox/Create
        public IActionResult Create()
        {
            return View("~/Views/Admin/CreateSuperBox.cshtml");  // Folosește subdirectorul Admin
        }

        // POST: SuperBox/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(SuperBox superBox)
        {
            if (ModelState.IsValid)
            {
                // Adăugăm obiectul SuperBox în baza de date
                _context.Add(superBox);
                _context.SaveChanges();  // Salvăm schimbările în baza de date

                // Setăm un mesaj de succes în TempData pentru a fi vizibil pe pagina curentă
                TempData["SuccessMessage"] = "SuperBox-ul a fost adăugat cu succes!";

                // Rămânem pe aceeași pagină după trimiterea formularului
                return View("~/Views/Admin/CreateSuperBox.cshtml");
            }

            // Dacă modelul nu este valid, returnează formularul cu erori
            return View("~/Views/Admin/CreateSuperBox.cshtml", superBox);
        }
    }
}