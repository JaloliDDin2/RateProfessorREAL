using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyRateApp2.Data;
using MyRateApp2.Models;

namespace MyRateApp2.Controllers
{
    [Authorize]
    public class UniversitiesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UniversitiesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Universities
        public async Task<IActionResult> Index()
        {
            if (_context.University == null)
            {
                return Problem("Entity set 'ApplicationDbContext.University' is null.");
            }
            else
            {
                // Filter to only include approved universities
                var approvedUniversities = await _context.University
                                                         .Where(u => u.IsApproved)
                                                         .ToListAsync();
                return View(approvedUniversities);
            }
        }

        // GET: Universities/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.University == null)
            {
                return NotFound();
            }

            var university = await _context.University
                .FirstOrDefaultAsync(m => m.UniId == id);
            if (university == null)
            {
                return NotFound();
            }

            return View(university);
        }


        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> PendingApproval()
        {
            var unapprovedUniversities = await _context.University
                                                        .Where(u => !u.IsApproved)
                                                        .ToListAsync();
            return View(unapprovedUniversities);
        }



        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Approve(int id)
        {
            var university = await _context.University.FirstOrDefaultAsync(u => u.UniId == id);
            if (university != null)
            {
                university.IsApproved = true;
                await _context.SaveChangesAsync();
                // Optionally redirect to the list of universities pending approval
                return RedirectToAction(nameof(PendingApproval));
            }
            return NotFound();
        }



        // GET: Universities/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Universities/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UniId,Name,Country,State,City,Website,Email,OverallQuality")] University university)
        {
            if (ModelState.IsValid)
            {
                university.IsApproved = false;
                _context.Add(university);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(university);
        }


        // GET: Universities/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.University == null)
            {
                return NotFound();
            }

            var university = await _context.University.FindAsync(id);
            if (university == null)
            {
                return NotFound();
            }
            return View(university);
        }

        // POST: Universities/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UniId,Name,Country,State,City,Website,Email,OverallQuality")] University university)
        {
            if (id != university.UniId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(university);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UniversityExists(university.UniId))
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
            return View(university);
        }

        // GET: Universities/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.University == null)
            {
                return NotFound();
            }

            var university = await _context.University
                .FirstOrDefaultAsync(m => m.UniId == id);
            if (university == null)
            {
                return NotFound();
            }

            return View(university);
        }

        // POST: Universities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.University == null)
            {
                return Problem("Entity set 'ApplicationDbContext.University'  is null.");
            }
            var university = await _context.University.FindAsync(id);
            if (university != null)
            {
                _context.University.Remove(university);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UniversityExists(int id)
        {
          return (_context.University?.Any(e => e.UniId == id)).GetValueOrDefault();
        }
    }
}
