using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DeveloperManagement.Context;

namespace DeveloperManagement.Controllers
{
    public class DevelopersController : Controller
    {
        private readonly DevelopersContext _context;

        public DevelopersController(DevelopersContext context)
        {
            _context = context;
        }

        // GET: Developers
        public async Task<IActionResult> Index()
        {
            return View(await _context.Developers.ToListAsync());
        }

        // GET: Developers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var developers = await _context.Developers
                .FirstOrDefaultAsync(m => m.DeveloperId == id);
            if (developers == null)
            {
                return NotFound();
            }

            return View(developers);
        }

        // GET: Developers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Developers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DeveloperId,Name,Age,JobTitle")] List<Developers> developers)
        {
            if (ModelState.IsValid)
            {
                await _context.AddRangeAsync(developers);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(developers);
        }

        // GET: Developers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var developers = await _context.Developers.FindAsync(id);
            if (developers == null)
            {
                return NotFound();
            }
            return View(developers);
        }

        // POST: Developers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DeveloperId,Name,Age,JobTitle")] Developers developers)
        {
            if (id != developers.DeveloperId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(developers);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DevelopersExists(developers.DeveloperId))
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
            return View(developers);
        }

        // GET: Developers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var developers = await _context.Developers
                .FirstOrDefaultAsync(m => m.DeveloperId == id);
            if (developers == null)
            {
                return NotFound();
            }

            return View(developers);
        }

        // POST: Developers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var developers = await _context.Developers.FindAsync(id);
            _context.Developers.Remove(developers);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DevelopersExists(int id)
        {
            return _context.Developers.Any(e => e.DeveloperId == id);
        }
    }
}
