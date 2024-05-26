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
    public class StaffInProcessesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StaffInProcessesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: StaffInProcesses
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.StaffInProcesses.Include(s => s.DocumentsProcesses).Include(s => s.RefStaffRoles).Include(s => s.Staff);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: StaffInProcesses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.StaffInProcesses == null)
            {
                return NotFound();
            }

            var staffInProcesses = await _context.StaffInProcesses
                .Include(s => s.DocumentsProcesses)
                .Include(s => s.RefStaffRoles)
                .Include(s => s.Staff)
                .FirstOrDefaultAsync(m => m.DocumentId == id);
            if (staffInProcesses == null)
            {
                return NotFound();
            }

            return View(staffInProcesses);
        }

        // GET: StaffInProcesses/Create
        public IActionResult Create()
        {
            ViewData["DocumentId"] = new SelectList(_context.DocumentsProcesses, "DocumentId", "DocumentId");
            ViewData["StaffRoleCode"] = new SelectList(_context.RefStaffRoles, "StaffRoleCode", "StaffRoleCode");
            ViewData["StaffId"] = new SelectList(_context.Staff, "StaffId", "StaffId");
            return View();
        }

        // POST: StaffInProcesses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DocumentId,ProcessId,StaffId,StaffRoleCode,DateFrom,DateTo,OtherDetails")] StaffInProcesses staffInProcesses)
        {
            if (ModelState.IsValid)
            {
                _context.Add(staffInProcesses);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DocumentId"] = new SelectList(_context.DocumentsProcesses, "DocumentId", "DocumentId", staffInProcesses.DocumentId);
            ViewData["StaffRoleCode"] = new SelectList(_context.RefStaffRoles, "StaffRoleCode", "StaffRoleCode", staffInProcesses.StaffRoleCode);
            ViewData["StaffId"] = new SelectList(_context.Staff, "StaffId", "StaffId", staffInProcesses.StaffId);
            return View(staffInProcesses);
        }

        // GET: StaffInProcesses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.StaffInProcesses == null)
            {
                return NotFound();
            }

            var staffInProcesses = await _context.StaffInProcesses.FindAsync(id);
            if (staffInProcesses == null)
            {
                return NotFound();
            }
            ViewData["DocumentId"] = new SelectList(_context.DocumentsProcesses, "DocumentId", "DocumentId", staffInProcesses.DocumentId);
            ViewData["StaffRoleCode"] = new SelectList(_context.RefStaffRoles, "StaffRoleCode", "StaffRoleCode", staffInProcesses.StaffRoleCode);
            ViewData["StaffId"] = new SelectList(_context.Staff, "StaffId", "StaffId", staffInProcesses.StaffId);
            return View(staffInProcesses);
        }

        // POST: StaffInProcesses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DocumentId,ProcessId,StaffId,StaffRoleCode,DateFrom,DateTo,OtherDetails")] StaffInProcesses staffInProcesses)
        {
            if (id != staffInProcesses.DocumentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(staffInProcesses);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StaffInProcessesExists(staffInProcesses.DocumentId))
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
            ViewData["DocumentId"] = new SelectList(_context.DocumentsProcesses, "DocumentId", "DocumentId", staffInProcesses.DocumentId);
            ViewData["StaffRoleCode"] = new SelectList(_context.RefStaffRoles, "StaffRoleCode", "StaffRoleCode", staffInProcesses.StaffRoleCode);
            ViewData["StaffId"] = new SelectList(_context.Staff, "StaffId", "StaffId", staffInProcesses.StaffId);
            return View(staffInProcesses);
        }

        // GET: StaffInProcesses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.StaffInProcesses == null)
            {
                return NotFound();
            }

            var staffInProcesses = await _context.StaffInProcesses
                .Include(s => s.DocumentsProcesses)
                .Include(s => s.RefStaffRoles)
                .Include(s => s.Staff)
                .FirstOrDefaultAsync(m => m.DocumentId == id);
            if (staffInProcesses == null)
            {
                return NotFound();
            }

            return View(staffInProcesses);
        }

        // POST: StaffInProcesses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.StaffInProcesses == null)
            {
                return Problem("Entity set 'ApplicationDbContext.StaffInProcesses'  is null.");
            }
            var staffInProcesses = await _context.StaffInProcesses.FindAsync(id);
            if (staffInProcesses != null)
            {
                _context.StaffInProcesses.Remove(staffInProcesses);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StaffInProcessesExists(int id)
        {
          return (_context.StaffInProcesses?.Any(e => e.DocumentId == id)).GetValueOrDefault();
        }
    }
}
