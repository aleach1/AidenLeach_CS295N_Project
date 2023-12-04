using JJBAWiki.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace JJBAWiki.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Part1()
        {
            return View();
        }

        public IActionResult Part2()
        {
            return View();
        }

        public IActionResult Part3()
        {
            return View();
        }

        public IActionResult Part4()
        {
            return View();
        }

        public IActionResult Part5()
        {
            return View();
        }

        public IActionResult Part6()
        {
            return View();
        }

        public IActionResult Part7()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}