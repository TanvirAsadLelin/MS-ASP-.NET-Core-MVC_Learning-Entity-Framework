using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CRUD_DatabaseFirstApproachEF.Models;

namespace CRUD_DatabaseFirstApproachEF.Controllers
{
    public class ParentsDetailsController : Controller
    {
        private readonly CRUD_DatabaseFirstApproach_DBContext _context;

        public ParentsDetailsController(CRUD_DatabaseFirstApproach_DBContext context)
        {
            _context = context;
        }

        // GET: ParentsDetails
        public async Task<IActionResult> Index()
        {
              return _context.StdParentsDetailsTbls != null ? 
                          View(await _context.StdParentsDetailsTbls.ToListAsync()) :
                          Problem("Entity set 'CRUD_DatabaseFirstApproach_DBContext.StdParentsDetailsTbls'  is null.");
        }

        // GET: ParentsDetails/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.StdParentsDetailsTbls == null)
            {
                return NotFound();
            }

            var stdParentsDetailsTbl = await _context.StdParentsDetailsTbls
                .FirstOrDefaultAsync(m => m.Id == id);
            if (stdParentsDetailsTbl == null)
            {
                return NotFound();
            }

            return View(stdParentsDetailsTbl);
        }

        // GET: ParentsDetails/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ParentsDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FatherName,MotherName,Address")] StdParentsDetailsTbl stdParentsDetailsTbl)
        {
            if (ModelState.IsValid)
            {
                _context.Add(stdParentsDetailsTbl);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(stdParentsDetailsTbl);
        }

        // GET: ParentsDetails/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.StdParentsDetailsTbls == null)
            {
                return NotFound();
            }

            var stdParentsDetailsTbl = await _context.StdParentsDetailsTbls.FindAsync(id);
            if (stdParentsDetailsTbl == null)
            {
                return NotFound();
            }
            return View(stdParentsDetailsTbl);
        }

        // POST: ParentsDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FatherName,MotherName,Address")] StdParentsDetailsTbl stdParentsDetailsTbl)
        {
            if (id != stdParentsDetailsTbl.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(stdParentsDetailsTbl);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StdParentsDetailsTblExists(stdParentsDetailsTbl.Id))
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
            return View(stdParentsDetailsTbl);
        }

        // GET: ParentsDetails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.StdParentsDetailsTbls == null)
            {
                return NotFound();
            }

            var stdParentsDetailsTbl = await _context.StdParentsDetailsTbls
                .FirstOrDefaultAsync(m => m.Id == id);
            if (stdParentsDetailsTbl == null)
            {
                return NotFound();
            }

            return View(stdParentsDetailsTbl);
        }

        // POST: ParentsDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.StdParentsDetailsTbls == null)
            {
                return Problem("Entity set 'CRUD_DatabaseFirstApproach_DBContext.StdParentsDetailsTbls'  is null.");
            }
            var stdParentsDetailsTbl = await _context.StdParentsDetailsTbls.FindAsync(id);
            if (stdParentsDetailsTbl != null)
            {
                _context.StdParentsDetailsTbls.Remove(stdParentsDetailsTbl);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StdParentsDetailsTblExists(int id)
        {
          return (_context.StdParentsDetailsTbls?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
