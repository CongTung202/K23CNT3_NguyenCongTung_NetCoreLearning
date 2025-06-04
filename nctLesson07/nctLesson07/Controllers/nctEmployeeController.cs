using Microsoft.AspNetCore.Mvc;
using nctLesson7.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace nctLesson7.Controllers
{
    public class nctEmployeeController : Controller
    {
        private static List<nctEmployee> nctListEmployee = new List<nctEmployee>
        {
            new nctEmployee { nctId = 1, nctName = "Nguyễn Công Tùng", nctBirthDay = new DateTime(2005, 02, 20), nctEmail = "nct30000@gmail.com", nctPhone = "0334402527", nctSalary = 12000000, nctStatus = true },
            new nctEmployee { nctId = 2, nctName = "Nguyễn Trần Frieren", nctBirthDay = new DateTime(2005, 7, 20), nctEmail = "frierenneet@gmail.com", nctPhone = "0987234142", nctSalary = 10000000, nctStatus = true },
            new nctEmployee { nctId = 3, nctName = "Lê Thị Mai Chese", nctBirthDay = new DateTime(2005, 03, 30), nctEmail = "CheseHotPot@gmail.com", nctPhone = "0987654321", nctSalary = 11000000, nctStatus = false },
            new nctEmployee { nctId = 4, nctName = "Trịnh Trần Helen", nctBirthDay = new DateTime(2005, 5, 22), nctEmail = "CoBonMaster@gmail.com", nctPhone = "0321456789", nctSalary = 13000000, nctStatus = true },
            new nctEmployee { nctId = 5, nctName = "Vương Thị Mến", nctBirthDay = new DateTime(2005, 8, 6), nctEmail = "MenTromCho12y@gmail.com", nctPhone = "0971332146", nctSalary = 5000000, nctStatus = true }
        };
        public IActionResult nctIndex()
        {
            return View(nctListEmployee);
        }
        public IActionResult nctDetails(int id)
        {
            var nctEmployee = nctListEmployee.FirstOrDefault(x => x.nctId == id);
            return View(nctEmployee);
        }
        public IActionResult nctCreate()
        {
            var nctEmployee = new nctEmployee();
            return View(nctEmployee);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult nctCreate(nctEmployee nctModel)
        {
            if (!ModelState.IsValid)
            {
                return View(nctModel);
            }

            // Tạo id mới tự động
            nctModel.nctId = nctListEmployee.Any() ? nctListEmployee.Max(e => e.nctId) + 1 : 1;
            nctListEmployee.Add(nctModel);

            return RedirectToAction(nameof(nctIndex));
        }

        public IActionResult nctEdit(int id)
        {
            var nctEmployee = nctListEmployee.FirstOrDefault(x => x.nctId == id);
            if (nctEmployee == null)
            {
                return NotFound();
            }
            return View(nctEmployee);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult nctEdit(int id, nctEmployee nctModel)
        {
            try
            {
                for(int i = 0; i < nctListEmployee.Count; i++)
                {
                    if (nctListEmployee[i].nctId == id)
                    {
                        nctListEmployee[i] = nctModel;
                        break;  
                }   }
                return RedirectToAction(nameof(nctIndex));
            }
            catch
            {
                return View();
            }
        }
        // GET: nctEmployee/nctDelete/5
        public IActionResult nctDelete(int id)
        {
            var nctEmployee = nctListEmployee.FirstOrDefault(x => x.nctId == id);
            if (nctEmployee == null)
            {
                return NotFound();
            }
            return View(nctEmployee);
        }
        // POST: nctEmployee/nctDelete/5
        [HttpPost, ActionName("nctDelete")]
        [ValidateAntiForgeryToken]
        public IActionResult nctDeleteConfirmed(int id)
        {
            var nctEmployee = nctListEmployee.FirstOrDefault(x => x.nctId == id);
            if (nctEmployee != null)
            {
                nctListEmployee.Remove(nctEmployee);
            }
            return RedirectToAction(nameof(nctIndex));
        }
    }
}