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


        public UniversityRatingsController(ApplicationDbContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: UniversityRatings
        public async Task<IActionResult> Index()
        {
            var ratings = await _context.UniversityRating.ToListAsync();
            return View(ratings);
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
            // Only allow users to rate their own university
            var user = _userManager.GetUserAsync(User).Result;

            if (user == null || user.UniversityId == null)
            {
                return Unauthorized(); // Or redirect to an error page
            }

            // If authorized, show the create view
            return View();
        }

        // POST: UniversityRatings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UniRatingId, Reputation, Opportunity, Happiness, Facilities, Location, Safety, Clubs, Social, Internet, Food, Overall, CreationDate, Comment, UniId")] UniversityRating universityRating)
        {
            var user = await _userManager.GetUserAsync(User);

            if (user == null || user.UniversityId == null || user.UniversityId != universityRating.UniId)
            {
                return Unauthorized(); // Or redirect to an error page
            }

            if (ModelState.IsValid)
            {
                _context.Add(universityRating);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(universityRating);
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
                    _context.Update(universityRating);
                    await _context.SaveChangesAsync();
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
