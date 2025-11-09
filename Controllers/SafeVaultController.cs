using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;
using SafeVault.DataAccess;

namespace SafeVault.Controllers
{
    public class SafeVaultController : Controller
    {
        [HttpGet]
        public IActionResult WebForm() => View();

        [HttpPost]
        public IActionResult Submit(string username, string email)
        {
            username = SanitizeInput(username);
            email = SanitizeInput(email);

            if (!Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                return BadRequest("Invalid email format");
            }

            DatabaseHelper.InsertUser(username, email);
            return Ok("Data saved securely!");
        }

        private string SanitizeInput(string input)
        {
            return Regex.Replace(input, @"[<>""'%;()&+]", "");
        }
    }
}