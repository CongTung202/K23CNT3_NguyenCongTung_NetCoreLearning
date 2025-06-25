using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using nctLesson10.Models;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace nctLesson10.Controllers
{
    public class NctPostsController : Controller
    {
        private readonly NctK23cnt3Lesson10dbContext _context;

        public NctPostsController(NctK23cnt3Lesson10dbContext context)
        {
            _context = context;
        }

        // GET: NctPosts
        public async Task<IActionResult> Index()
        {
            return View(await _context.NctPosts.ToListAsync());
        }

        // GET: NctPosts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nctPost = await _context.NctPosts
                .FirstOrDefaultAsync(m => m.NctId == id);
            if (nctPost == null)
            {
                return NotFound();
            }

            return View(nctPost);
        }

        // GET: NctPosts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: NctPosts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("NctId,NctTitle,NctContent,NctStatus")] NctPost nctPost, IFormFile ImageFile)
        {
            if (ModelState.IsValid)
            {
                if (ImageFile != null && ImageFile.Length > 0)
                {
                    var fileName = Path.GetFileNameWithoutExtension(ImageFile.FileName);
                    var extension = Path.GetExtension(ImageFile.FileName);
                    var uniqueFileName = $"{fileName}_{Guid.NewGuid()}{extension}";
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", uniqueFileName);

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await ImageFile.CopyToAsync(stream);
                    }

                    nctPost.NctImage = "/images/" + uniqueFileName;
                }

                _context.Add(nctPost);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(nctPost);
        }

        // GET: NctPosts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nctPost = await _context.NctPosts.FindAsync(id);
            if (nctPost == null)
            {
                return NotFound();
            }
            return View(nctPost);
        }

        // POST: NctPosts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("NctId,NctTitle,NctImage,NctContent,NctStatus")] NctPost nctPost, IFormFile ImageFile)
        {
            if (id != nctPost.NctId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    // Get the existing post from the database
                    var existingPost = await _context.NctPosts.AsNoTracking().FirstOrDefaultAsync(p => p.NctId == id);
                    if (existingPost == null)
                        return NotFound();

                    // If a new image is uploaded, save it and update the path
                    if (ImageFile != null && ImageFile.Length > 0)
                    {
                        var fileName = Path.GetFileNameWithoutExtension(ImageFile.FileName);
                        var extension = Path.GetExtension(ImageFile.FileName);
                        var uniqueFileName = $"{fileName}_{Guid.NewGuid()}{extension}";
                        var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", uniqueFileName);

                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            await ImageFile.CopyToAsync(stream);
                        }

                        nctPost.NctImage = "/images/" + uniqueFileName;
                    }
                    else
                    {
                        // Keep the old image if no new image is uploaded
                        nctPost.NctImage = existingPost.NctImage;
                    }

                    _context.Update(nctPost);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NctPostExists(nctPost.NctId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(nctPost);
        }

        // GET: NctPosts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nctPost = await _context.NctPosts
                .FirstOrDefaultAsync(m => m.NctId == id);
            if (nctPost == null)
            {
                return NotFound();
            }

            return View(nctPost);
        }

        // POST: NctPosts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var nctPost = await _context.NctPosts.FindAsync(id);
            if (nctPost != null)
            {
                _context.NctPosts.Remove(nctPost);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NctPostExists(int id)
        {
            return _context.NctPosts.Any(e => e.NctId == id);
        }
    }
}
