using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NguyenCongTung_2310900051.Models;

namespace NguyenCongTung_2310900051.Controllers
{
    public class NctEmployeesController : Controller
    {
        private readonly NguyenCongTung2310900051Context _context;

        public NctEmployeesController(NguyenCongTung2310900051Context context)
        {
            _context = context;
        }

        // GET: NctEmployees
        public async Task<IActionResult> nctIndex()
        {
            return View(await _context.NctEmployees.ToListAsync());
        }

        // GET: NctEmployees/Details/5
        public async Task<IActionResult> nctDetails(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nctEmployee = await _context.NctEmployees
                .FirstOrDefaultAsync(m => m.NctEmpId == id);
            if (nctEmployee == null)
            {
                return NotFound();
            }

            return View(nctEmployee);
        }

        // GET: NctEmployees/Create
        public IActionResult nctCreate()
        {
            return View();
        }

        // POST: NctEmployees/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> nctCreate([Bind("NctEmpId,NctEmpName,NctEmpLevel,NctEmpStartDate,NctEmpStatus")] NctEmployee nctEmployee)
        {
            if (ModelState.IsValid)
            {
                _context.Add(nctEmployee);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(nctIndex));
            }
            return View(nctEmployee);
        }

        // GET: NctEmployees/Edit/5
        public async Task<IActionResult> nctEdit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nctEmployee = await _context.NctEmployees.FindAsync(id);
            if (nctEmployee == null)
            {
                return NotFound();
            }
            return View(nctEmployee);
        }

        // POST: NctEmployees/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> nctEdit(string id, [Bind("NctEmpId,NctEmpName,NctEmpLevel,NctEmpStartDate,NctEmpStatus")] NctEmployee nctEmployee)
        {
            if (id != nctEmployee.NctEmpId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nctEmployee);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NctEmployeeExists(nctEmployee.NctEmpId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(nctIndex));
            }
            return View(nctEmployee);
        }

        // GET: NctEmployees/Delete/5
        public async Task<IActionResult> nctDelete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nctEmployee = await _context.NctEmployees
                .FirstOrDefaultAsync(m => m.NctEmpId == id);
            if (nctEmployee == null)
            {
                return NotFound();
            }

            return View(nctEmployee);
        }

        // POST: NctEmployees/Delete/5
        [HttpPost, ActionName("nctDelete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> nctDeleteConfirmed(string id)
        {
            var nctEmployee = await _context.NctEmployees.FindAsync(id);
            if (nctEmployee != null)
            {
                _context.NctEmployees.Remove(nctEmployee);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(nctIndex));
        }

        private bool NctEmployeeExists(string id)
        {
            return _context.NctEmployees.Any(e => e.NctEmpId == id);
        }
    }
}
