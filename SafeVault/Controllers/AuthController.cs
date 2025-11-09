using Microsoft.AspNetCore.Mvc;
using SafeVault.DataAccess;
using BCrypt.Net;

namespace SafeVault.Controllers
{
    public class AuthController : Controller
    {
        [HttpGet]
        public IActionResult Login() => View();

        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            var user = DatabaseHelper.GetUserByUsername(username);
            if (user == null || !BCrypt.Net.BCrypt.Verify(password, user.PasswordHash))
            {
                return Unauthorized("Invalid credentials");
            }

            HttpContext.Session.SetString("Role", user.Role);
            return RedirectToAction("Dashboard");
        }

        [HttpGet]
        public IActionResult Dashboard()
        {
            var role = HttpContext.Session.GetString("Role");
            if (role != "admin")
            {
                return Forbid("Access denied");
            }
            return View("AdminDashboard");
        }
    }
}