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
    public class MatchController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MatchController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Match
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Match.Include(m => m.Team1).Include(m => m.Team2).Include(m => m.Tournament);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Match/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var match = await _context.Match
                .Include(m => m.Team1)
                .Include(m => m.Team2)
                .Include(m => m.Tournament)
                .FirstOrDefaultAsync(m => m.MatchId == id);
            if (match == null)
            {
                return NotFound();
            }

            return View(match);
        }

        // GET: Match/Create
        public IActionResult Create()
        {
            ViewData["Team1Id"] = new SelectList(_context.Set<Team>(), "TeamId", "TeamId");
            ViewData["Team2Id"] = new SelectList(_context.Set<Team>(), "TeamId", "TeamId");
            ViewData["TournamentId"] = new SelectList(_context.Set<Tournament>(), "TournamentId", "TournamentId");
            return View();
        }

        // POST: Match/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MatchId,TournamentId,MatchDate,ScoreTeam1,ScoreTeam2,IsFinished,Team1Id,Team2Id")] Match match)
        {
            if (ModelState.IsValid)
            {
                _context.Add(match);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Team1Id"] = new SelectList(_context.Set<Team>(), "TeamId", "TeamId", match.Team1Id);
            ViewData["Team2Id"] = new SelectList(_context.Set<Team>(), "TeamId", "TeamId", match.Team2Id);
            ViewData["TournamentId"] = new SelectList(_context.Set<Tournament>(), "TournamentId", "TournamentId", match.TournamentId);
            return View(match);
        }

        // GET: Match/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var match = await _context.Match.FindAsync(id);
            if (match == null)
            {
                return NotFound();
            }
            ViewData["Team1Id"] = new SelectList(_context.Set<Team>(), "TeamId", "TeamId", match.Team1Id);
            ViewData["Team2Id"] = new SelectList(_context.Set<Team>(), "TeamId", "TeamId", match.Team2Id);
            ViewData["TournamentId"] = new SelectList(_context.Set<Tournament>(), "TournamentId", "TournamentId", match.TournamentId);
            return View(match);
        }

        // POST: Match/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MatchId,TournamentId,MatchDate,ScoreTeam1,ScoreTeam2,IsFinished,Team1Id,Team2Id")] Match match)
        {
            if (id != match.MatchId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(match);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MatchExists(match.MatchId))
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
            ViewData["Team1Id"] = new SelectList(_context.Set<Team>(), "TeamId", "TeamId", match.Team1Id);
            ViewData["Team2Id"] = new SelectList(_context.Set<Team>(), "TeamId", "TeamId", match.Team2Id);
            ViewData["TournamentId"] = new SelectList(_context.Set<Tournament>(), "TournamentId", "TournamentId", match.TournamentId);
            return View(match);
        }

        // GET: Match/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var match = await _context.Match
                .Include(m => m.Team1)
                .Include(m => m.Team2)
                .Include(m => m.Tournament)
                .FirstOrDefaultAsync(m => m.MatchId == id);
            if (match == null)
            {
                return NotFound();
            }

            return View(match);
        }

        // POST: Match/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var match = await _context.Match.FindAsync(id);
            if (match != null)
            {
                _context.Match.Remove(match);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MatchExists(int id)
        {
            return _context.Match.Any(e => e.MatchId == id);
        }
    }
}
