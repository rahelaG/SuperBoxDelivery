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
        [HttpPost]
        public IActionResult LogIn(string username, string password)
        {
            var user = _context.Users.FirstOrDefault(u => u.UserName == username);

            if (user != null && user.VerifyPassword(password))
            {
                TempData["SuccessMessage"] = "You have successfully logged in!";
                return RedirectToAction("UserHomePage", "Account");
            }
            ModelState.AddModelError("", "Invalid username or password.");
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
            var existingUser = _context.Users.FirstOrDefault(u => u.UserName == username);
            if (existingUser != null)
            {
                ModelState.AddModelError("UserName", "Username is already taken.");
                return View();
            }
            var user = new User { UserName = username, Email = email };
            user.SetPassword(password);

            _context.Users.Add(user);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult UserHomePage()
        {
            return View();
        }
    }
}