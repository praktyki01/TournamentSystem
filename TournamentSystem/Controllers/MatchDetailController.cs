using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TournamentSystem.Data;
using TournamentSystem.Models;

namespace TournamentSystem.Controllers
{
    public class MatchDetailController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MatchDetailController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: MatchDetail
        public async Task<IActionResult> Index()
        {
            return View(await _context.MatchDetail.ToListAsync());
        }

        // GET: MatchDetail/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var matchDetail = await _context.MatchDetail
                .FirstOrDefaultAsync(m => m.MatchDetailId == id);
            if (matchDetail == null)
            {
                return NotFound();
            }

            return View(matchDetail);
        }

        // GET: MatchDetail/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MatchDetail/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MatchDetailId,Number,ScoreTeam1,ScoreTeam2")] MatchDetail matchDetail)
        {
            if (ModelState.IsValid)
            {
                _context.Add(matchDetail);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(matchDetail);
        }

        // GET: MatchDetail/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var matchDetail = await _context.MatchDetail.FindAsync(id);
            if (matchDetail == null)
            {
                return NotFound();
            }
            return View(matchDetail);
        }

        // POST: MatchDetail/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MatchDetailId,Number,ScoreTeam1,ScoreTeam2")] MatchDetail matchDetail)
        {
            if (id != matchDetail.MatchDetailId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(matchDetail);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MatchDetailExists(matchDetail.MatchDetailId))
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
            return View(matchDetail);
        }

        // GET: MatchDetail/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var matchDetail = await _context.MatchDetail
                .FirstOrDefaultAsync(m => m.MatchDetailId == id);
            if (matchDetail == null)
            {
                return NotFound();
            }

            return View(matchDetail);
        }

        // POST: MatchDetail/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var matchDetail = await _context.MatchDetail.FindAsync(id);
            if (matchDetail != null)
            {
                _context.MatchDetail.Remove(matchDetail);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MatchDetailExists(int id)
        {
            return _context.MatchDetail.Any(e => e.MatchDetailId == id);
        }
    }
}
