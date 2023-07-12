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
    public class NinjaClansController : Controller
    {
        private readonly ApplicationDbContext _context;

        public NinjaClansController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: NinjaClans
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.NinjaClan.Include(n => n.Shinobi);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: NinjaClans/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.NinjaClan == null)
            {
                return NotFound();
            }

            var ninjaClan = await _context.NinjaClan
                .Include(n => n.Shinobi)
                .FirstOrDefaultAsync(m => m.NinjaClanId == id);
            if (ninjaClan == null)
            {
                return NotFound();
            }

            return View(ninjaClan);
        }

        // GET: NinjaClans/Create
        public IActionResult Create()
        {
            ViewData["ShinobiId"] = new SelectList(_context.Shinobi, "ShinobiId", "Name");
            return View();
        }

        // POST: NinjaClans/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("NinjaClanId,Name,ShinobiId")] NinjaClan ninjaClan)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ninjaClan);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ShinobiId"] = new SelectList(_context.Shinobi, "ShinobiId", "Name", ninjaClan.ShinobiId);
            return View(ninjaClan);
        }

        // GET: NinjaClans/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.NinjaClan == null)
            {
                return NotFound();
            }

            var ninjaClan = await _context.NinjaClan.FindAsync(id);
            if (ninjaClan == null)
            {
                return NotFound();
            }
            ViewData["ShinobiId"] = new SelectList(_context.Shinobi, "ShinobiId", "Name", ninjaClan.ShinobiId);
            return View(ninjaClan);
        }

        // POST: NinjaClans/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("NinjaClanId,Name,ShinobiId")] NinjaClan ninjaClan)
        {
            if (id != ninjaClan.NinjaClanId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ninjaClan);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NinjaClanExists(ninjaClan.NinjaClanId))
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
            ViewData["ShinobiId"] = new SelectList(_context.Shinobi, "ShinobiId", "Name", ninjaClan.ShinobiId);
            return View(ninjaClan);
        }

        // GET: NinjaClans/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.NinjaClan == null)
            {
                return NotFound();
            }

            var ninjaClan = await _context.NinjaClan
                .Include(n => n.Shinobi)
                .FirstOrDefaultAsync(m => m.NinjaClanId == id);
            if (ninjaClan == null)
            {
                return NotFound();
            }

            return View(ninjaClan);
        }

        // POST: NinjaClans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.NinjaClan == null)
            {
                return Problem("Entity set 'ApplicationDbContext.NinjaClan'  is null.");
            }
            var ninjaClan = await _context.NinjaClan.FindAsync(id);
            if (ninjaClan != null)
            {
                _context.NinjaClan.Remove(ninjaClan);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NinjaClanExists(int id)
        {
          return (_context.NinjaClan?.Any(e => e.NinjaClanId == id)).GetValueOrDefault();
        }
    }
}
