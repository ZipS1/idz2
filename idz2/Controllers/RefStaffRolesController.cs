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
    public class RefStaffRolesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RefStaffRolesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: RefStaffRoles
        public async Task<IActionResult> Index()
        {
              return _context.RefStaffRoles != null ? 
                          View(await _context.RefStaffRoles.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.RefStaffRoles'  is null.");
        }

        // GET: RefStaffRoles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.RefStaffRoles == null)
            {
                return NotFound();
            }

            var refStaffRoles = await _context.RefStaffRoles
                .FirstOrDefaultAsync(m => m.StaffRoleCode == id);
            if (refStaffRoles == null)
            {
                return NotFound();
            }

            return View(refStaffRoles);
        }

        // GET: RefStaffRoles/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: RefStaffRoles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StaffRoleCode,StaffRoleDescription")] RefStaffRoles refStaffRoles)
        {
            if (ModelState.IsValid)
            {
                _context.Add(refStaffRoles);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(refStaffRoles);
        }

        // GET: RefStaffRoles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.RefStaffRoles == null)
            {
                return NotFound();
            }

            var refStaffRoles = await _context.RefStaffRoles.FindAsync(id);
            if (refStaffRoles == null)
            {
                return NotFound();
            }
            return View(refStaffRoles);
        }

        // POST: RefStaffRoles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("StaffRoleCode,StaffRoleDescription")] RefStaffRoles refStaffRoles)
        {
            if (id != refStaffRoles.StaffRoleCode)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(refStaffRoles);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RefStaffRolesExists(refStaffRoles.StaffRoleCode))
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
            return View(refStaffRoles);
        }

        // GET: RefStaffRoles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.RefStaffRoles == null)
            {
                return NotFound();
            }

            var refStaffRoles = await _context.RefStaffRoles
                .FirstOrDefaultAsync(m => m.StaffRoleCode == id);
            if (refStaffRoles == null)
            {
                return NotFound();
            }

            return View(refStaffRoles);
        }

        // POST: RefStaffRoles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.RefStaffRoles == null)
            {
                return Problem("Entity set 'ApplicationDbContext.RefStaffRoles'  is null.");
            }
            var refStaffRoles = await _context.RefStaffRoles.FindAsync(id);
            if (refStaffRoles != null)
            {
                _context.RefStaffRoles.Remove(refStaffRoles);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RefStaffRolesExists(int id)
        {
          return (_context.RefStaffRoles?.Any(e => e.StaffRoleCode == id)).GetValueOrDefault();
        }
    }
}
