using Microsoft.AspNetCore.Mvc;
using nctLesson2.Models;

namespace nctLesson2.Controllers
{
    public class nctGetProductsController : Controller
    {
        public IActionResult nctIndex()
        {
            ViewData["MessageVD"] = "Du Lieu Luu Trong View Data |Boka.net";
            ViewBag.MessageVB = "Du Lieu Luu Trong View Bag |Boka.vn";
            TempData["MessageTD"] = "Du Lieu Luu Trong TempData |Boka.Extreme";
            return View();
        }
        public IActionResult nctGetProducts()
        {
            nctProduct p = new nctProduct
            {
                ProductId = 1,ProductName="Boka Chan",YearRelease="2025-20-02",Price=7000000
            };
            ViewBag.nctProduct = p;
            ViewData["nctProduct"] = p;
            return View();
        }
    }

}
