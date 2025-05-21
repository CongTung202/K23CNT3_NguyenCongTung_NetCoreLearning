using Microsoft.AspNetCore.Mvc;
using nctLesson4.Models;
using System.Collections.Generic;

namespace nctLesson4.Controllers
{
    public class nctListFriendsController : Controller
    {
        // Static list to store friends in memory
        private static List<nctListFriends> friends = new List<nctListFriends>
        {
            new nctListFriends
            {
                ID=1,
                Age = 18,
                Name = "Lê Quang Liêm",
                Address = "Ocean Park",
                Image = "/images/bokachan.jpg",
                Email = "bokachan@gmail.com"
            },
            new nctListFriends
            {
                ID=2,
                Age = 20,
                Name = "Nguyễn Trần Hutao",
                Address = "Hà Nội",
                Image = "/images/hutao.jpg",
                Email = "hutao@gmail.com"
            },
            new nctListFriends
            {
                ID=3,
                Age = 19,
                Name = "Bô Thị Mai CChi",
                Address = "Đà Nẵng",
                Image = "/images/bocchi.jpg",
                Email = "bocchi@gmail.com"
            },
            new nctListFriends
            {
                ID=4,
                Age = 22,
                Name = "Lê Thị Ma Ki",
                Address = "Bắc Bling",
                Image = "/images/Makima.jpg",
                Email = "Makima@gmail.com"
            },
            new nctListFriends
            {
                ID=5,
                Age = 22,
                Name = "Nguyễn Ngọc Reze",
                Address = "Hưng Yên",
                Image = "/images/Reze.jpg",
                Email = "Rezebombgirl@gmail.com"
            },
            new nctListFriends
            {
                ID=6,
                Age = 22,
                Name = "Trần Thị Asa",
                Address = "Nghệ An",
                Image = "/images/Asa.jpg",
                Email = "AsaTheWar@gmail.com"
            }
        };

        public IActionResult nctListFriends()
        {
            ViewBag.Friends = friends;
            return View();
        }
        public IActionResult nctListFriendsBox()
        {
            ViewBag.Friends = friends;
            return View();
        }
        [HttpGet]
        public IActionResult nctCreateFriends()
        {
            nctListFriends nctListFriends = new nctListFriends();
            return View(nctListFriends);
        }


        [HttpPost]
        public IActionResult nctCreateSubmitFriends(nctListFriends friend)
        {
            // Tự động tăng ID
            friend.ID = friends.Count > 0 ? friends[^1].ID + 1 : 1;
            friends.Add(friend);
            return RedirectToAction("nctListFriends");
        }

        public IActionResult nctDetailsFriends(int id)
        {
            var friend = friends.Find(f => f.ID == id);
            if (friend == null)
                return NotFound();
            return View(friend);
        }
        [HttpGet]
        public IActionResult nctEditFriends(int id)
        {
            var friend = friends.Find(f => f.ID == id);
            if (friend == null)
                return NotFound();
            return View(friend);
        }

        [HttpPost]
        public IActionResult nctEditSubmitFriends(nctListFriends updatedFriend)
        {
            var friend = friends.Find(f => f.ID == updatedFriend.ID);
            if (friend != null)
            {
                friend.Name = updatedFriend.Name;
                friend.Age = updatedFriend.Age;
                friend.Address = updatedFriend.Address;
                friend.Image = updatedFriend.Image;
                friend.Email = updatedFriend.Email;
            }
            return RedirectToAction("nctListFriends");
        }

        // Hiển thị form xác nhận xóa
        [HttpGet]
        public IActionResult nctDeleteFriends(int id)
        {
            var friend = friends.Find(f => f.ID == id);
            if (friend == null)
                return NotFound();
            return View(friend);
        }

        // Thực hiện xóa
        [HttpPost, ActionName("nctDeleteFriends")]
        public IActionResult nctDeleteFriendsConfirmed(int id)
        {
            var friend = friends.Find(f => f.ID == id);
            if (friend != null)
            {
                friends.Remove(friend);
            }
            return RedirectToAction("nctListFriends");
        }
    }
}
