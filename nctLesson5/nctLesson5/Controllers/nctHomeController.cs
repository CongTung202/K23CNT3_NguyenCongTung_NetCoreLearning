using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using nctLesson5.Models;

namespace nctLesson5.Controllers
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
            nctMember nctMember = new nctMember();
            nctMember.id = "2310900051";
            nctMember.nctName = "Nguyen Cong Tung";
            nctMember.nctPassword = "BokaChan123@";
            nctMember.nctEmail = "nct30000@gmail.com";

            return View(nctMember);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
