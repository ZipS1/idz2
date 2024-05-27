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
    public class BusinessProcessesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BusinessProcessesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: BusinessProcesses
        public async Task<IActionResult> Index()
        {
              return _context.BusinessProcesses != null ? 
                          View(await _context.BusinessProcesses.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.BusinessProcesses'  is null.");
        }

        // GET: BusinessProcesses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.BusinessProcesses == null)
            {
                return NotFound();
            }

            var businessProcesses = await _context.BusinessProcesses
                .FirstOrDefaultAsync(m => m.ProcessId == id);
            if (businessProcesses == null)
            {
                return NotFound();
            }

            return View(businessProcesses);
        }

        // GET: BusinessProcesses/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BusinessProcesses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProcessId,ProcessName,ProcessDescription,OtherDetails")] BusinessProcesses businessProcesses)
        {
            if (ModelState.IsValid)
            {
                _context.Add(businessProcesses);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(businessProcesses);
        }

        // GET: BusinessProcesses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.BusinessProcesses == null)
            {
                return NotFound();
            }

            var businessProcesses = await _context.BusinessProcesses.FindAsync(id);
            if (businessProcesses == null)
            {
                return NotFound();
            }
            return View(businessProcesses);
        }

        // POST: BusinessProcesses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProcessId,ProcessName,ProcessDescription,OtherDetails")] BusinessProcesses businessProcesses)
        {
            if (id != businessProcesses.ProcessId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(businessProcesses);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BusinessProcessesExists(businessProcesses.ProcessId))
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
            return View(businessProcesses);
        }

        // GET: BusinessProcesses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.BusinessProcesses == null)
            {
                return NotFound();
            }

            var businessProcesses = await _context.BusinessProcesses
                .FirstOrDefaultAsync(m => m.ProcessId == id);
            if (businessProcesses == null)
            {
                return NotFound();
            }

            return View(businessProcesses);
        }

        // POST: BusinessProcesses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.BusinessProcesses == null)
            {
                return Problem("Entity set 'ApplicationDbContext.BusinessProcesses'  is null.");
            }
            var businessProcesses = await _context.BusinessProcesses.FindAsync(id);
            if (businessProcesses != null)
            {
                _context.BusinessProcesses.Remove(businessProcesses);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BusinessProcessesExists(int id)
        {
          return (_context.BusinessProcesses?.Any(e => e.ProcessId == id)).GetValueOrDefault();
        }
    }
}
