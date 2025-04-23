using Microsoft.AspNetCore.Mvc;
using NctLession1Mvc.Models;
using System.Diagnostics;

namespace NctLession1Mvc.Controllers
{
    public class NctHomeController : Controller
    {
        private readonly ILogger<NctHomeController> _logger;

        public NctHomeController(ILogger<NctHomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
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
