using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DemoMVC.Data;
using DemoMVC.Models;

namespace DemoMVC.Controllers
{
    public class ExportController : Controller
    {
        private readonly AppDbContext _context;

        public ExportController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Export
        public async Task<IActionResult> Index()
        {
            var data = _context.Exports;
            return View(await data.ToListAsync());
        }

        // GET: Export/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var export = await _context.Exports
                .Include(i => i.ExportDetails)
                .ThenInclude(d => d.Product)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (export == null) return NotFound();

            return View(export);
        }

        // GET: Export/Create
        public IActionResult Create()
        {
            ViewBag.Products = _context.Products.ToList();
            return View();
        }

        // POST: Export/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Export export, List<ExportDetail> details)
        {
            if (details == null || !details.Any())
            {
                ModelState.AddModelError("", "Phải có ít nhất 1 sản phẩm");
            }

            if (ModelState.IsValid)
            {
                _context.Exports.Add(export);
                await _context.SaveChangesAsync();

                foreach (var item in details)
                {
                    item.ExportId = export.Id;
                    _context.ExportDetails.Add(item);
                }

                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            ViewBag.Products = _context.Products.ToList();
            return View(export);
        }

        // GET: Export/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var export = await _context.Exports.FindAsync(id);
            if (export == null) return NotFound();

            return View(export);
        }

        // POST: Export/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Export export)
        {
            if (id != export.Id) return NotFound();

            if (ModelState.IsValid)
            {
                _context.Update(export);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(export);
        }

        // GET: Export/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var export = await _context.Exports
                .FirstOrDefaultAsync(m => m.Id == id);

            if (export == null) return NotFound();

            return View(export);
        }

        // POST: Export/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var export = await _context.Exports.FindAsync(id);

            if (export != null)
            {
                _context.Exports.Remove(export);
            }

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}