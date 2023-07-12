using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CoreMvc.Data;
using CoreMvc.Models;

namespace CoreMvc.Controllers
{
    public class ShinobisController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ShinobisController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Shinobis
        public async Task<IActionResult> Index()
        {
              return _context.Shinobi != null ? 
                          View(await _context.Shinobi.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Shinobi'  is null.");
        }

        // GET: Shinobis/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Shinobi == null)
            {
                return NotFound();
            }

            var shinobi = await _context.Shinobi
                .FirstOrDefaultAsync(m => m.ShinobiId == id);
            if (shinobi == null)
            {
                return NotFound();
            }

            return View(shinobi);
        }

        // GET: Shinobis/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Shinobis/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ShinobiId,Name")] Shinobi shinobi)
        {
            if (ModelState.IsValid)
            {
                _context.Add(shinobi);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(shinobi);
        }

        // GET: Shinobis/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Shinobi == null)
            {
                return NotFound();
            }

            var shinobi = await _context.Shinobi.FindAsync(id);
            if (shinobi == null)
            {
                return NotFound();
            }
            return View(shinobi);
        }

        // POST: Shinobis/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ShinobiId,Name")] Shinobi shinobi)
        {
            if (id != shinobi.ShinobiId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(shinobi);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ShinobiExists(shinobi.ShinobiId))
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
            return View(shinobi);
        }

        // GET: Shinobis/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Shinobi == null)
            {
                return NotFound();
            }

            var shinobi = await _context.Shinobi
                .FirstOrDefaultAsync(m => m.ShinobiId == id);
            if (shinobi == null)
            {
                return NotFound();
            }

            return View(shinobi);
        }

        // POST: Shinobis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Shinobi == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Shinobi'  is null.");
            }
            var shinobi = await _context.Shinobi.FindAsync(id);
            if (shinobi != null)
            {
                _context.Shinobi.Remove(shinobi);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ShinobiExists(int id)
        {
          return (_context.Shinobi?.Any(e => e.ShinobiId == id)).GetValueOrDefault();
        }
    }
}
