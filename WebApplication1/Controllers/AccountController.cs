using Microsoft.AspNetCore.Mvc;
namespace WebApplication1.Controllers;
public class AccountController: Controller
{
        public IActionResult LogIn()
        {
            return View();
        }
        public IActionResult SignUp()
        {
            return View();
        }
    }
