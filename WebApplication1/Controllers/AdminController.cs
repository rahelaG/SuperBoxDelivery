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
        private readonly ILogger<AdminController> _logger;

        public AdminController(ApplicationDbContext context, ILogger<AdminController> logger)
        {
            _context = context;
            _logger = logger;
        }

        [HttpPost]
        public IActionResult AddAdmin(string usernameOrEmail)
        {
            _logger.LogInformation("AddAdmin called by user {Username} with parameter {UsernameOrEmail}.", User.Identity?.Name, usernameOrEmail);

            if (string.IsNullOrWhiteSpace(usernameOrEmail))
            {
                _logger.LogWarning("AddAdmin was called with an empty username or email.");
                TempData["ErrorMessage"] = "Invalid username or email.";
                return RedirectToAction("AdminHomePage");
            }

            var user = _context.Users
                .FirstOrDefault(u => u.UserName == usernameOrEmail || u.Email == usernameOrEmail);

            if (user == null)
            {
                _logger.LogWarning("User {UsernameOrEmail} not found for promotion to admin.", usernameOrEmail);
                TempData["ErrorMessage"] = "User not found.";
                return RedirectToAction("AdminHomePage");
            }

            if (user.IsAdmin)
            {
                _logger.LogInformation("User {UsernameOrEmail} is already an admin.", usernameOrEmail);
                TempData["Message"] = "User is already an admin.";
                return RedirectToAction("AdminHomePage");
            }

            user.IsAdmin = true;
            _context.SaveChanges();

            _logger.LogInformation("User {UsernameOrEmail} successfully promoted to admin.", usernameOrEmail);
            TempData["Message"] = "User promoted to admin!";
            return RedirectToAction("AdminHomePage");
        }

        [Authorize(Roles = "Admin")]
        public IActionResult AdminHomePage()
        {
            _logger.LogInformation("AdminHomePage accessed by user {Username}.", User.Identity?.Name);

            if (User.Identity == null || !User.Identity.IsAuthenticated)
            {
                _logger.LogWarning("Unauthorized access attempt to AdminHomePage.");
                return Unauthorized("You must be logged in to access this page.");
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            _logger.LogInformation("Logout called by user {Username}.", User.Identity?.Name);

            if (User.Identity == null || !User.Identity.IsAuthenticated)
            {
                _logger.LogWarning("Logout attempt by an unauthenticated user.");
                return Unauthorized("You are not logged in.");
            }

            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            _logger.LogInformation("User {Username} successfully logged out.", User.Identity?.Name);
            return RedirectToAction("LogIn", "Account");
        }

        [HttpPost]
        public IActionResult ChangeOrderStatus(int orderId)
        {
            _logger.LogInformation("ChangeOrderStatus called for order ID {OrderId} by user {Username}.", orderId, User.Identity?.Name);

            if (orderId <= 0)
            {
                _logger.LogWarning("Invalid order ID {OrderId} provided.", orderId);
                return BadRequest("Invalid order ID.");
            }

            var order = _context.Orders.FirstOrDefault(o => o.OrderId == orderId);

            if (order == null)
            {
                _logger.LogWarning("Order with ID {OrderId} not found.", orderId);
                return NotFound("Order not found.");
            }

            if (order.Status == OrderStatus.Canceled)
            {
                _logger.LogInformation("Attempt to change status of a canceled order {OrderId}.", orderId);
                return BadRequest("The order is already canceled and cannot be delivered.");
            }

            if (order.Status != OrderStatus.Delivered)
            {
                order.Status = OrderStatus.Delivered;
                _context.SaveChanges();

                _logger.LogInformation("Order {OrderId} status successfully changed to Delivered by {Username}.", orderId, User.Identity?.Name);
            }
            else
            {
                _logger.LogInformation("Order {OrderId} is already marked as Delivered.", orderId);
            }

            return RedirectToAction("ViewAllOrders", "Account");
        }
    }
}
