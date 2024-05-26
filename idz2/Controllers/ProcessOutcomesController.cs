using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using idz2.Data;
using idz2.Models;

namespace idz2.Controllers
{
    public class ProcessOutcomesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProcessOutcomesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ProcessOutcomes
        public async Task<IActionResult> Index()
        {
              return _context.ProcessOutcomes != null ? 
                          View(await _context.ProcessOutcomes.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.ProcessOutcomes'  is null.");
        }

        // GET: ProcessOutcomes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ProcessOutcomes == null)
            {
                return NotFound();
            }

            var processOutcomes = await _context.ProcessOutcomes
                .FirstOrDefaultAsync(m => m.ProcessOutcomeCode == id);
            if (processOutcomes == null)
            {
                return NotFound();
            }

            return View(processOutcomes);
        }

        // GET: ProcessOutcomes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ProcessOutcomes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProcessOutcomeCode,ProcessOutcomeDescription")] ProcessOutcomes processOutcomes)
        {
            if (ModelState.IsValid)
            {
                _context.Add(processOutcomes);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(processOutcomes);
        }

        // GET: ProcessOutcomes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ProcessOutcomes == null)
            {
                return NotFound();
            }

            var processOutcomes = await _context.ProcessOutcomes.FindAsync(id);
            if (processOutcomes == null)
            {
                return NotFound();
            }
            return View(processOutcomes);
        }

        // POST: ProcessOutcomes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProcessOutcomeCode,ProcessOutcomeDescription")] ProcessOutcomes processOutcomes)
        {
            if (id != processOutcomes.ProcessOutcomeCode)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(processOutcomes);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProcessOutcomesExists(processOutcomes.ProcessOutcomeCode))
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
            return View(processOutcomes);
        }

        // GET: ProcessOutcomes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ProcessOutcomes == null)
            {
                return NotFound();
            }

            var processOutcomes = await _context.ProcessOutcomes
                .FirstOrDefaultAsync(m => m.ProcessOutcomeCode == id);
            if (processOutcomes == null)
            {
                return NotFound();
            }

            return View(processOutcomes);
        }

        // POST: ProcessOutcomes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ProcessOutcomes == null)
            {
                return Problem("Entity set 'ApplicationDbContext.ProcessOutcomes'  is null.");
            }
            var processOutcomes = await _context.ProcessOutcomes.FindAsync(id);
            if (processOutcomes != null)
            {
                _context.ProcessOutcomes.Remove(processOutcomes);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProcessOutcomesExists(int id)
        {
          return (_context.ProcessOutcomes?.Any(e => e.ProcessOutcomeCode == id)).GetValueOrDefault();
        }
    }
}
