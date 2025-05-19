using AirBnbWAD.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AirbnbWAD.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index() => View();
        public IActionResult Listings() => View();
        public IActionResult Details() => View();
        public IActionResult Create() => View();
        public IActionResult About() => View();
        public IActionResult Contact() => View();
        public IActionResult Privacy() => View();

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string username, string password)
        {

            if (username == "admin" && password == "password")
            {
                return RedirectToAction("Index");
            }

            ViewBag.Error = "Invalid username or password";
            return View();
        }
        public IActionResult Register()
        {
            return View();
        }



    }

}