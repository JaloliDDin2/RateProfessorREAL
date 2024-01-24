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
    public class ProfessorRatingsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProfessorRatingsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ProfessorRatings
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.ProfessorRating.Include(p => p.Prof);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: ProfessorRatings/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null || _context.ProfessorRating == null)
            {
                return NotFound();
            }

            var professorRating = await _context.ProfessorRating
                .Include(p => p.Prof)
                .FirstOrDefaultAsync(m => m.ProfRateId == id);
            if (professorRating == null)
            {
                return NotFound();
            }

            return View(professorRating);
        }

        // GET: ProfessorRatings/Create
        public IActionResult Create()
        {
            ViewData["ProfId"] = new SelectList(_context.Professor, "ProfId", "ProfId");
            return View();
        }

        // POST: ProfessorRatings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProfRateId,ProfGrade,Comment,Attendance,WouldTakeAgain,LevelOfDifficulty,CourseCode,Textbook,CreationDate,Grade,ForCredit,ProfId")] ProfessorRating professorRating)
        {
            if (ModelState.IsValid)
            {
                professorRating.CalculateQuality();

                _context.Add(professorRating);
                await _context.SaveChangesAsync();

                UpdateOverallQuality(professorRating.ProfId);

                return RedirectToAction(nameof(Index));
            }
            ViewData["ProfId"] = new SelectList(_context.Professor, "ProfId", "ProfId", professorRating.ProfId);
            return View(professorRating);
        }

        public void UpdateOverallQuality(int? professorId)
        {
            var professor = _context.Professor
                .Include(u => u.ProfessorRatings) // Include ratings for eager loading
                .FirstOrDefault(u => u.ProfId == professorId);

            if (professor != null)
            {
                // Calculate average overall quality
                double averageOverallQuality = professor.ProfessorRatings.Average(r => r.AverageQuality);

                // Update overall quality property
                professor.Overall = averageOverallQuality;

                // Save changes to the database
                _context.SaveChanges();
            }
        }

        // GET: ProfessorRatings/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null || _context.ProfessorRating == null)
            {
                return NotFound();
            }

            var professorRating = await _context.ProfessorRating.FindAsync(id);
            if (professorRating == null)
            {
                return NotFound();
            }
            ViewData["ProfId"] = new SelectList(_context.Professor, "ProfId", "ProfId", professorRating.ProfId);
            return View(professorRating);
        }

        // POST: ProfessorRatings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("ProfRateId,ProfGrade,Comment,Attendance,WouldTakeAgain,LevelOfDifficulty,CourseCode,Textbook,CreationDate,Grade,ForCredit,ProfId")] ProfessorRating professorRating)
        {
            if (id != professorRating.ProfRateId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(professorRating);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProfessorRatingExists(professorRating.ProfRateId))
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
            ViewData["ProfId"] = new SelectList(_context.Professor, "ProfId", "ProfId", professorRating.ProfId);
            return View(professorRating);
        }

        // GET: ProfessorRatings/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null || _context.ProfessorRating == null)
            {
                return NotFound();
            }

            var professorRating = await _context.ProfessorRating
                .Include(p => p.Prof)
                .FirstOrDefaultAsync(m => m.ProfRateId == id);
            if (professorRating == null)
            {
                return NotFound();
            }

            return View(professorRating);
        }

        // POST: ProfessorRatings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            if (_context.ProfessorRating == null)
            {
                return Problem("Entity set 'ApplicationDbContext.ProfessorRating'  is null.");
            }
            var professorRating = await _context.ProfessorRating.FindAsync(id);
            if (professorRating != null)
            {
                _context.ProfessorRating.Remove(professorRating);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProfessorRatingExists(long id)
        {
          return (_context.ProfessorRating?.Any(e => e.ProfRateId == id)).GetValueOrDefault();
        }
    }
}
