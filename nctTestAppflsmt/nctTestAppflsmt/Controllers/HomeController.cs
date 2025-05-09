using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using nctTestAppflsmt.Models;

namespace nctTestAppflsmt.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult nctIndex()
        {
            return View();
        }

        public IActionResult nctPrivacy()
        {
            return View();
        }
        public IActionResult nctHome()
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
