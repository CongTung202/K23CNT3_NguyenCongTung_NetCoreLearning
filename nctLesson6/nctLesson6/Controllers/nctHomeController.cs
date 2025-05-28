using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using nctLesson6.Models;

namespace nctLesson6.Controllers
{
    public class nctHomeController : Controller
    {
        private readonly ILogger<nctHomeController> _logger;

        public nctHomeController(ILogger<nctHomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult nctIndex()
        {
            return View();
        }

        public IActionResult nctAbout()
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
