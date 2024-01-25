using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyRateApp2.Data;
using MyRateApp2.Models;

namespace MyRateApp2.Controllers
{
    [Authorize]
    public class UniversityRatingsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<User> _userManager;
        public UniversityRatingsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: UniversityRatings
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.UniversityRating.Include(u => u.Uni);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: UniversityRatings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.UniversityRating == null)
            {
                return NotFound();
            }

            var universityRating = await _context.UniversityRating
                .Include(u => u.Uni)
                .FirstOrDefaultAsync(m => m.UniRatingId == id);
            if (universityRating == null)
            {
                return NotFound();
            }

            return View(universityRating);
        }

        // GET: UniversityRatings/Create
        public IActionResult Create()
        {

            ViewData["UniId"] = new SelectList(_context.University, "UniId", "UniId");
            return View();
        }

        // POST: UniversityRatings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UniRatingId,Reputation,Opportunity,Happiness,Facilities,Location,Safety,Clubs,Social,Internet,Food,Overall,CreationDate,Comment,UniId,UserId")] UniversityRating universityRating)
        {
            if (ModelState.IsValid)
            {
                universityRating.CalculateOverallRating(); // Calculate the overall rating

                UpdateOverallQuality(universityRating.UniId);
                _context.Add(universityRating);
                await _context.SaveChangesAsync();

                //    double averageRating = _context.UniversityRating
                //.Where(r => r.UserId == userId && r.UniId == universityRating.UniId)
                //.Average(r => r.Overall);

                return RedirectToAction(nameof(Index));
            }
            ViewData["UniId"] = new SelectList(_context.University, "UniId", "UniId", universityRating.UniId);

            return View(universityRating);
        }

        public void UpdateOverallQuality(int? universityId)
        {
            var university = _context.University
                .Include(u => u.UniversityRatings) // Include ratings for eager loading
                .FirstOrDefault(u => u.UniId == universityId);

            if (university != null)
            {
                // Calculate average overall quality
                double averageOverallQuality = university.UniversityRatings.Average(r => r.Overall);

                // Update overall quality property
                university.OverallQuality = averageOverallQuality;

                // Save changes to the database
                _context.SaveChanges();
            }
        }

        // GET: UniversityRatings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.UniversityRating == null)
            {
                return NotFound();
            }

            var universityRating = await _context.UniversityRating.FindAsync(id);
            if (universityRating == null)
            {
                return NotFound();
            }
            ViewData["UniId"] = new SelectList(_context.University, "UniId", "UniId", universityRating.UniId);
            return View(universityRating);
        }

        // POST: UniversityRatings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UniRatingId,Reputation,Opportunity,Happiness,Facilities,Location,Safety,Clubs,Social,Internet,Food,Overall,CreationDate,Comment,UniId")] UniversityRating universityRating)
        {
            if (id != universityRating.UniRatingId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    universityRating.CalculateOverallRating();
                    _context.Update(universityRating);
                    await _context.SaveChangesAsync();

                    UpdateOverallQuality(universityRating.UniId);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UniversityRatingExists(universityRating.UniRatingId))
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
            ViewData["UniId"] = new SelectList(_context.University, "UniId", "UniId", universityRating.UniId);
            return View(universityRating);
        }

        // GET: UniversityRatings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.UniversityRating == null)
            {
                return NotFound();
            }

            var universityRating = await _context.UniversityRating
                .Include(u => u.Uni)
                .FirstOrDefaultAsync(m => m.UniRatingId == id);
            if (universityRating == null)
            {
                return NotFound();
            }

            return View(universityRating);
        }

        // POST: UniversityRatings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.UniversityRating == null)
            {
                return Problem("Entity set 'ApplicationDbContext.UniversityRating'  is null.");
            }
            var universityRating = await _context.UniversityRating.FindAsync(id);
            if (universityRating != null)
            {
                _context.UniversityRating.Remove(universityRating);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UniversityRatingExists(int id)
        {
          return (_context.UniversityRating?.Any(e => e.UniRatingId == id)).GetValueOrDefault();
        }
    }
}
