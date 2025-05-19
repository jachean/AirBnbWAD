using Microsoft.AspNetCore.Mvc;
using AirBnbWAD.Services;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Threading.Tasks;

namespace AirBnbWAD.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAuthService _authService;

        public AccountController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpGet]
        public IActionResult Login() => View();

        [HttpPost]
        public async Task<IActionResult> Login(string email, string password)
        {
            var result = await _authService.LoginUserAsync(email, password);
            if (result.Succeeded)
                return RedirectToAction("Index", "Home");

            ViewBag.Error = "Invalid login attempt.";
            return View();
        }

        [HttpGet]
        public IActionResult Register() => View();

        [HttpPost]
        public async Task<IActionResult> Register(string username, string email, string password, string confirmPassword)
        {
            if (password != confirmPassword)
            {
                ViewBag.Error = "Passwords do not match.";
                return View();
            }

            var result = await _authService.RegisterUserAsync(username, email, password);
            if (result.Succeeded)
                return RedirectToAction("Login");

            ViewBag.Error = string.Join("<br/>", result.Errors.Select(e => e.Description));
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _authService.LogoutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
