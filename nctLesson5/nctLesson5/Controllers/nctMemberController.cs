using Microsoft.AspNetCore.Mvc;
using nctLesson5.Models;

namespace nctLesson5.Controllers
{
    public class nctMemberController : Controller
    {
        public static readonly List<nctMember> Members = new List<nctMember>()
        {
            new nctMember { id = Guid.NewGuid().ToString("N"), nctName = "Nguyen Cong Tung", nctPassword = "123456@", nctEmail = "nct30000@gmail.com" },
            new nctMember { id = Guid.NewGuid().ToString("N"), nctName = "Lê Quang Liêm", nctPassword = "masterchess123", nctEmail = "liemchessking102@gmail.com" },
            new nctMember { id = Guid.NewGuid().ToString("N"), nctName = "Trịnh Trần Boka", nctPassword = "Bokachan97", nctEmail = "bokacobon123@gmail.com" },
            new nctMember { id = Guid.NewGuid().ToString("N"), nctName = "Nguyễn Ngọc Reze", nctPassword = "bombtowin123", nctEmail = "bombmaster102@gmail.com" },
            new nctMember { id = Guid.NewGuid().ToString("N"), nctName = "Lê Thị Zuka", nctPassword = "zuka123netc", nctEmail = "doialazuka12@gmail.com" }
        };

        public IActionResult nctIndex()
        {
            return View(Members);
        }
    }
}
