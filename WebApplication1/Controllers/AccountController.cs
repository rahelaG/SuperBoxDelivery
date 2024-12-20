using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext _context;
        private static List<User> _users = new List<User>();

        public AccountController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult LogIn()
        {
            return View();
        }

        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SignUp(string username, string password, string email)
        {
            if (string.IsNullOrEmpty(password))
            {
                ModelState.AddModelError("Password", "Password is required.");
                return View();
            }

            var user = new User { UserName = username, Email = email };
            user.SetPassword(password);

            _context.Users.Add(user);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}