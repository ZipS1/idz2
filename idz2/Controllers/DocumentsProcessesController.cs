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
    public class DocumentsProcessesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DocumentsProcessesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: DocumentsProcesses
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.DocumentsProcesses.Include(d => d.BusinessProcesses).Include(d => d.Documents).Include(d => d.ProcessOutcomes).Include(d => d.ProcessStatus);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: DocumentsProcesses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.DocumentsProcesses == null)
            {
                return NotFound();
            }

            var documentsProcesses = await _context.DocumentsProcesses
                .Include(d => d.BusinessProcesses)
                .Include(d => d.Documents)
                .Include(d => d.ProcessOutcomes)
                .Include(d => d.ProcessStatus)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (documentsProcesses == null)
            {
                return NotFound();
            }

            return View(documentsProcesses);
        }

        // GET: DocumentsProcesses/Create
        public IActionResult Create()
        {
            ViewData["ProcessId"] = new SelectList(_context.BusinessProcesses, "ProcessId", "ProcessName");
            ViewData["DocumentId"] = new SelectList(_context.Documents, "DocumentId", "DocumentName");
            ViewData["ProcessOutcomeCode"] = new SelectList(_context.ProcessOutcomes, "ProcessOutcomeCode", "ProcessOutcomeDescription");
            ViewData["ProcessStatusCode"] = new SelectList(_context.ProcessStatus, "ProcessStatusCode", "ProcessStatusDescription");
            return View();
        }

        // POST: DocumentsProcesses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DocumentId,ProcessId,ProcessOutcomeCode,ProcessStatusCode")] DocumentsProcesses documentsProcesses)
        {
            if (ModelState.IsValid)
            {
                _context.Add(documentsProcesses);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProcessId"] = new SelectList(_context.BusinessProcesses, "ProcessId", "ProcessName", documentsProcesses.ProcessId);
            ViewData["DocumentId"] = new SelectList(_context.Documents, "DocumentId", "DocumentName", documentsProcesses.DocumentId);
            ViewData["ProcessOutcomeCode"] = new SelectList(_context.ProcessOutcomes, "ProcessOutcomeCode", "ProcessOutcomeDescription", documentsProcesses.ProcessOutcomeCode);
            ViewData["ProcessStatusCode"] = new SelectList(_context.ProcessStatus, "ProcessStatusCode", "ProcessStatusDescription", documentsProcesses.ProcessStatusCode);
            return View(documentsProcesses);
        }

        // GET: DocumentsProcesses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.DocumentsProcesses == null)
            {
                return NotFound();
            }

            var documentsProcesses = await _context.DocumentsProcesses.FindAsync(id);
            if (documentsProcesses == null)
            {
                return NotFound();
            }
            ViewData["ProcessId"] = new SelectList(_context.BusinessProcesses, "ProcessId", "ProcessName", documentsProcesses.ProcessId);
            ViewData["DocumentId"] = new SelectList(_context.Documents, "DocumentId", "DocumentName", documentsProcesses.DocumentId);
            ViewData["ProcessOutcomeCode"] = new SelectList(_context.ProcessOutcomes, "ProcessOutcomeCode", "ProcessOutcomeDescription", documentsProcesses.ProcessOutcomeCode);
            ViewData["ProcessStatusCode"] = new SelectList(_context.ProcessStatus, "ProcessStatusCode", "ProcessStatusDescription", documentsProcesses.ProcessStatusCode);
            return View(documentsProcesses);
        }

        // POST: DocumentsProcesses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DocumentId,ProcessId,ProcessOutcomeCode,ProcessStatusCode")] DocumentsProcesses documentsProcesses)
        {
            if (id != documentsProcesses.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(documentsProcesses);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DocumentsProcessesExists(documentsProcesses.Id))
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
            ViewData["ProcessId"] = new SelectList(_context.BusinessProcesses, "ProcessId", "ProcessName", documentsProcesses.ProcessId);
            ViewData["DocumentId"] = new SelectList(_context.Documents, "DocumentId", "DocumentName", documentsProcesses.DocumentId);
            ViewData["ProcessOutcomeCode"] = new SelectList(_context.ProcessOutcomes, "ProcessOutcomeCode", "ProcessOutcomeDescription", documentsProcesses.ProcessOutcomeCode);
            ViewData["ProcessStatusCode"] = new SelectList(_context.ProcessStatus, "ProcessStatusCode", "ProcessStatusDescription", documentsProcesses.ProcessStatusCode);
            return View(documentsProcesses);
        }

        // GET: DocumentsProcesses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.DocumentsProcesses == null)
            {
                return NotFound();
            }

            var documentsProcesses = await _context.DocumentsProcesses
                .Include(d => d.BusinessProcesses)
                .Include(d => d.Documents)
                .Include(d => d.ProcessOutcomes)
                .Include(d => d.ProcessStatus)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (documentsProcesses == null)
            {
                return NotFound();
            }

            return View(documentsProcesses);
        }

        // POST: DocumentsProcesses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.DocumentsProcesses == null)
            {
                return Problem("Entity set 'ApplicationDbContext.DocumentsProcesses'  is null.");
            }
            var documentsProcesses = await _context.DocumentsProcesses.FindAsync(id);
            if (documentsProcesses != null)
            {
                _context.DocumentsProcesses.Remove(documentsProcesses);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DocumentsProcessesExists(int id)
        {
          return (_context.DocumentsProcesses?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
