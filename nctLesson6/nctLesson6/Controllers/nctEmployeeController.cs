using Microsoft.AspNetCore.Mvc;
using nctLesson6.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace nctLesson6.Controllers
{
    public class nctEmployeeController : Controller
    {
        // Static list to simulate a data store
        private static List<nctEmployee> nctListEmployee = new List<nctEmployee>
        {
            new nctEmployee { nctId = 1, nctName = "Nguyễn Trần Frieren", nctBirthDay = new DateTime(2005, 7, 20), nctEmail = "frierenneet@gmail.com", nctPhone = "0987234142", nctSalary = 10000000, nctStatus = true },
            new nctEmployee { nctId = 2, nctName = "Nguyễn Công Tùng", nctBirthDay = new DateTime(2005, 02, 20), nctEmail = "nct30000@gmail.com", nctPhone = "0334402527", nctSalary = 12000000, nctStatus = true },
            new nctEmployee { nctId = 3, nctName = "Lê Thị Mai Chese", nctBirthDay = new DateTime(2005, 03, 30), nctEmail = "CheseHotPot@gmail.com", nctPhone = "0987654321", nctSalary = 11000000, nctStatus = false },
            new nctEmployee { nctId = 4, nctName = "Trịnh Trần Helen", nctBirthDay = new DateTime(2005, 5, 22), nctEmail = "CoBonMaster@gmail.com", nctPhone = "0321456789", nctSalary = 13000000, nctStatus = true },
            new nctEmployee { nctId = 5, nctName = "Vương Thị Mến", nctBirthDay = new DateTime(2005, 8, 6), nctEmail = "MenTromCho12y@gmail.com", nctPhone = "0971332146", nctSalary = 5000000, nctStatus = true }
        };

        // GET: /nctEmployee/nctIndex
        public IActionResult nctIndex()
        {
            return View(nctListEmployee);
        }

        // GET: /nctEmployee/nctCreate
        [HttpGet]
        public IActionResult nctCreate()
        {
            return View();
        }

        // POST: /nctEmployee/nctCreateSubmit
        [HttpPost]
        public IActionResult nctCreateSubmit(nctEmployee emp)
        {
            if (ModelState.IsValid)
            {
                emp.nctId = nctListEmployee.Max(e => e.nctId) + 1;
                nctListEmployee.Add(emp);
                return RedirectToAction("nctIndex");
            }
            return View("nctCreate", emp);
        }

        // GET: /nctEmployee/nctEdit/{id}
        [HttpGet]
        public IActionResult nctEdit(int Id)
        {
            var emp = nctListEmployee.FirstOrDefault(e => e.nctId == Id);
            if (emp == null)
                return NotFound();
            return View(emp);
        }

        // POST: /nctEmployee/nctEditPUT
        [HttpPost]
        public IActionResult nctEditPUT(nctEmployee emp)
        {
            var existing = nctListEmployee.FirstOrDefault(e => e.nctId == emp.nctId);
            if (existing == null)
                return NotFound();

            if (ModelState.IsValid)
            {
                existing.nctName = emp.nctName;
                existing.nctBirthDay = emp.nctBirthDay;
                existing.nctEmail = emp.nctEmail;
                existing.nctPhone = emp.nctPhone;
                existing.nctSalary = emp.nctSalary;
                existing.nctStatus = emp.nctStatus;
                return RedirectToAction("nctIndex");
            }
            return View("nctEdit", emp);
        }

        // GET: /nctEmployee/nctDelete/{id}
        public IActionResult nctDelete(int Id)
        {
            var emp = nctListEmployee.FirstOrDefault(e => e.nctId == Id);
            if (emp != null)
            {
                nctListEmployee.Remove(emp);
            }
            return RedirectToAction("nctIndex");
        }
    }
}