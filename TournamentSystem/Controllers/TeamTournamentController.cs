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
    public class TeamTournamentController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TeamTournamentController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TeamTournament
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.TeamTournament.Include(t => t.Team).Include(t => t.Tournament);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: TeamTournament/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var teamTournament = await _context.TeamTournament
                .Include(t => t.Team)
                .Include(t => t.Tournament)
                .FirstOrDefaultAsync(m => m.TeamTournamentId == id);
            if (teamTournament == null)
            {
                return NotFound();
            }

            return View(teamTournament);
        }

        // GET: TeamTournament/Create
        public IActionResult Create()
        {
            ViewData["TeamId"] = new SelectList(_context.Team, "TeamId", "TeamId");
            ViewData["TournamentId"] = new SelectList(_context.Set<Tournament>(), "TournamentId", "TournamentId");
            return View();
        }

        // POST: TeamTournament/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TeamTournamentId,RegistrationDate,Confirmed,TeamId,TournamentId")] TeamTournament teamTournament)
        {
            if (ModelState.IsValid)
            {
                _context.Add(teamTournament);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TeamId"] = new SelectList(_context.Team, "TeamId", "TeamId", teamTournament.TeamId);
            ViewData["TournamentId"] = new SelectList(_context.Set<Tournament>(), "TournamentId", "TournamentId", teamTournament.TournamentId);
            return View(teamTournament);
        }

        // GET: TeamTournament/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var teamTournament = await _context.TeamTournament.FindAsync(id);
            if (teamTournament == null)
            {
                return NotFound();
            }
            ViewData["TeamId"] = new SelectList(_context.Team, "TeamId", "TeamId", teamTournament.TeamId);
            ViewData["TournamentId"] = new SelectList(_context.Set<Tournament>(), "TournamentId", "TournamentId", teamTournament.TournamentId);
            return View(teamTournament);
        }

        // POST: TeamTournament/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TeamTournamentId,RegistrationDate,Confirmed,TeamId,TournamentId")] TeamTournament teamTournament)
        {
            if (id != teamTournament.TeamTournamentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(teamTournament);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TeamTournamentExists(teamTournament.TeamTournamentId))
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
            ViewData["TeamId"] = new SelectList(_context.Team, "TeamId", "TeamId", teamTournament.TeamId);
            ViewData["TournamentId"] = new SelectList(_context.Set<Tournament>(), "TournamentId", "TournamentId", teamTournament.TournamentId);
            return View(teamTournament);
        }

        // GET: TeamTournament/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var teamTournament = await _context.TeamTournament
                .Include(t => t.Team)
                .Include(t => t.Tournament)
                .FirstOrDefaultAsync(m => m.TeamTournamentId == id);
            if (teamTournament == null)
            {
                return NotFound();
            }

            return View(teamTournament);
        }

        // POST: TeamTournament/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var teamTournament = await _context.TeamTournament.FindAsync(id);
            if (teamTournament != null)
            {
                _context.TeamTournament.Remove(teamTournament);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TeamTournamentExists(int id)
        {
            return _context.TeamTournament.Any(e => e.TeamTournamentId == id);
        }
    }
}
