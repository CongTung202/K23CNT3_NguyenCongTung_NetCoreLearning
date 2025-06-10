using Microsoft.AspNetCore.Mvc;
using nctLesson8.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace nctLesson8.Controllers
{
    public class nctAccountController : Controller
    {
        // In-memory data store
        private static List<nctAccounts> nctAccounts = new List<nctAccounts>
        {
            new nctAccounts
            {
                nctId = "A001",
                nctFullName = "Nguyễn Công Tùng",
                nctEmail = "nct30000@gmail.com",
                nctPhone = "0334402527",
                nctAddress = "Hanoi",
                nctAvatar = "https://scontent.fhan15-1.fna.fbcdn.net/v/t39.30808-6/505403398_700253925970043_6609541582154932254_n.jpg?_nc_cat=1&ccb=1-7&_nc_sid=833d8c&_nc_ohc=EfwroG3P-Z0Q7kNvwFVIKKC&_nc_oc=AdnyGoRplbLzoT_Dq1cNXHSVSJHfd-b8v-2z8oj1qnm01aUmkHwVU4kFYt8f9Xh6FHdDv1STFwmXm-8I2RJ8BNNl&_nc_zt=23&_nc_ht=scontent.fhan15-1.fna&_nc_gid=JQlPpt1ybu2oHmjclWwW1A&oh=00_AfP9GkO0Acp0WIKswnbE0bvDOxu_ZY3pKW9a8SoCHPLdZg&oe=684D8C2A",
                nctBirthday = new DateTime(2005, 02, 20),
                nctPassword = "bokachan",
                nctFacebook = "fb.com"
            },
            new nctAccounts
            {
                nctId = "A002",
                nctFullName = "Nguyễn Trần Frieren",
                nctEmail = "frierenneet@gmail.com",
                nctPhone = "0987654321",
                nctAddress = "HCM",
                nctAvatar = "",
                nctBirthday =  new DateTime(2005, 7, 20),
                nctPassword = "frieren",
                nctFacebook = "fb.com"
            },
            new nctAccounts
            {
                nctId = "A003",
                nctFullName = "Lê Thị Mai Chese",
                nctEmail = "CheseHotPot@gmail.com",
                nctPhone = "0912345678",
                nctAddress = "Da Nang",
                nctAvatar = "",
                nctBirthday = new DateTime(2005, 03, 30),
                nctPassword = "chesee",
                nctFacebook = "fb.com"
            },
            new nctAccounts
            {
                nctId = "A004",
                nctFullName = "Trịnh Trần Helen",
                nctEmail = "CoBonMaster@gmail.com",
                nctPhone = "0934567890",
                nctAddress = "Can Tho",
                nctAvatar = "",
                nctBirthday = new DateTime(2005, 5, 22),
                nctPassword = "cobon112",
                nctFacebook = "fb.com"
            },
            new nctAccounts
            {
                nctId = "A005",
                nctFullName = "Vương Thị Mến",
                nctEmail = "MenTromCho12y@gmail.com",
                nctPhone = "0945678901",
                nctAddress = "Hai Phong",
                nctAvatar = "",
                nctBirthday = new DateTime(2005, 8, 6),
                nctPassword = "mentromcho",
                nctFacebook = "fb.com"
            }
        };

        // READ: List all accounts
        public IActionResult nctIndex()
        {
            return View(nctAccounts);
        }

        // READ: Details
        public IActionResult nctDetails(string id)
        {
            var acc = nctAccounts.FirstOrDefault(a => a.nctId == id);
            if (acc == null) return NotFound();
            return View(acc);
        }

        // CREATE: GET
        public IActionResult nctCreate()
        {
            return View();
        }

        // CREATE: POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult nctCreate(nctAccounts account)
        {
            if (!ModelState.IsValid)
                return View(account);

            if (nctAccounts.Any(a => a.nctId == account.nctId))
            {
                ModelState.AddModelError("nctId", "Id đã tồn tại");
                return View(account);
            }

            nctAccounts.Add(account);
            return RedirectToAction(nameof(nctIndex));
        }

        // UPDATE: GET
        public IActionResult nctEdit(string id)
        {
            var acc = nctAccounts.FirstOrDefault(a => a.nctId == id);
            if (acc == null) return NotFound();
            return View(acc);
        }

        // UPDATE: POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult nctEdit(string id, nctAccounts account)
        {
            if (!ModelState.IsValid)
                return View(account);

            var acc = nctAccounts.FirstOrDefault(a => a.nctId == id);
            if (acc == null) return NotFound();

            // Update fields
            acc.nctFullName = account.nctFullName;
            acc.nctEmail = account.nctEmail;
            acc.nctPhone = account.nctPhone;
            acc.nctAddress = account.nctAddress;
            acc.nctAvatar = account.nctAvatar;
            acc.nctBirthday = account.nctBirthday;
            acc.nctPassword = account.nctPassword;
            acc.nctFacebook = account.nctFacebook;

            return RedirectToAction(nameof(nctIndex));
        }

        // DELETE: GET
        public IActionResult nctDelete(string id)
        {
            var acc = nctAccounts.FirstOrDefault(a => a.nctId == id);
            if (acc == null) return NotFound();
            return View(acc);
        }

        // DELETE: POST
        [HttpPost, ActionName("nctDelete")]
        [ValidateAntiForgeryToken]
        public IActionResult nctDeleteConfirmed(string id)
        {
            var acc = nctAccounts.FirstOrDefault(a => a.nctId == id);
            if (acc == null) return NotFound();

            nctAccounts.Remove(acc);
            return RedirectToAction(nameof(nctIndex));
        }
    }
}