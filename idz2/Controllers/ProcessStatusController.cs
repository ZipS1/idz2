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
    public class ProcessStatusController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProcessStatusController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ProcessStatus
        public async Task<IActionResult> Index()
        {
              return _context.ProcessStatus != null ? 
                          View(await _context.ProcessStatus.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.ProcessStatus'  is null.");
        }

        // GET: ProcessStatus/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ProcessStatus == null)
            {
                return NotFound();
            }

            var processStatus = await _context.ProcessStatus
                .FirstOrDefaultAsync(m => m.ProcessStatusCode == id);
            if (processStatus == null)
            {
                return NotFound();
            }

            return View(processStatus);
        }

        // GET: ProcessStatus/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ProcessStatus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProcessStatusCode,ProcessStatusDescription")] ProcessStatus processStatus)
        {
            if (ModelState.IsValid)
            {
                _context.Add(processStatus);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(processStatus);
        }

        // GET: ProcessStatus/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ProcessStatus == null)
            {
                return NotFound();
            }

            var processStatus = await _context.ProcessStatus.FindAsync(id);
            if (processStatus == null)
            {
                return NotFound();
            }
            return View(processStatus);
        }

        // POST: ProcessStatus/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProcessStatusCode,ProcessStatusDescription")] ProcessStatus processStatus)
        {
            if (id != processStatus.ProcessStatusCode)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(processStatus);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProcessStatusExists(processStatus.ProcessStatusCode))
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
            return View(processStatus);
        }

        // GET: ProcessStatus/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ProcessStatus == null)
            {
                return NotFound();
            }

            var processStatus = await _context.ProcessStatus
                .FirstOrDefaultAsync(m => m.ProcessStatusCode == id);
            if (processStatus == null)
            {
                return NotFound();
            }

            return View(processStatus);
        }

        // POST: ProcessStatus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ProcessStatus == null)
            {
                return Problem("Entity set 'ApplicationDbContext.ProcessStatus'  is null.");
            }
            var processStatus = await _context.ProcessStatus.FindAsync(id);
            if (processStatus != null)
            {
                _context.ProcessStatus.Remove(processStatus);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProcessStatusExists(int id)
        {
          return (_context.ProcessStatus?.Any(e => e.ProcessStatusCode == id)).GetValueOrDefault();
        }
    }
}
