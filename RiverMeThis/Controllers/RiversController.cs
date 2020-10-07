using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RiverMeThis.Data;
using RiverMeThis.Models;

namespace RiverMeThis.Controllers
{
    public class RiversController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RiversController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Rivers
        public async Task<IActionResult> Index()
        {
            return View(await _context.River.ToListAsync());
        }

        // GET: Rivers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var river = await _context.River
                .FirstOrDefaultAsync(m => m.RiverId == id);
            if (river == null)
            {
                return NotFound();
            }

            return View(river);
        }

        // GET: Rivers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Rivers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RiverId,Name,TotalLength,NumAPs,MapPath")] River river)
        {
            if (ModelState.IsValid)
            {
                _context.Add(river);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(river);
        }

        // GET: Rivers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var river = await _context.River.FindAsync(id);
            if (river == null)
            {
                return NotFound();
            }
            return View(river);
        }

        // POST: Rivers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RiverId,Name,TotalLength,NumAPs,MapPath")] River river)
        {
            if (id != river.RiverId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(river);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RiverExists(river.RiverId))
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
            return View(river);
        }

        // GET: Rivers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var river = await _context.River
                .FirstOrDefaultAsync(m => m.RiverId == id);
            if (river == null)
            {
                return NotFound();
            }

            return View(river);
        }

        // POST: Rivers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var river = await _context.River.FindAsync(id);
            _context.River.Remove(river);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RiverExists(int id)
        {
            return _context.River.Any(e => e.RiverId == id);
        }
    }
}
