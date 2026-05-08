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
    public class ImportController : Controller
    {
        private readonly AppDbContext _context;

        public ImportController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Import
        public async Task<IActionResult> Index()
        {
            var data = _context.Imports
                .Include(i => i.Supplier);
            return View(await data.ToListAsync());
        }

        // GET: Import/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var import = await _context.Imports
                .Include(i => i.Supplier)
                .Include(i => i.ImportDetails)
                .ThenInclude(d => d.Product)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (import == null) return NotFound();

            return View(import);
        }

        // GET: Import/Create
        public IActionResult Create()
        {
            ViewBag.Suppliers = new SelectList(_context.Suppliers, "Id", "Name");
            ViewBag.Products = _context.Products.ToList();
            return View();
        }

        // POST: Import/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Import import, List<ImportDetail> details)
        {
            if (details == null || !details.Any())
            {
                ModelState.AddModelError("", "Phải có ít nhất 1 sản phẩm");
            }

            if (ModelState.IsValid)
            {
                _context.Imports.Add(import);
                await _context.SaveChangesAsync();

                foreach (var item in details)
                {
                    item.ImportId = import.Id;
                    _context.ImportDetails.Add(item);
                }

                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            ViewBag.Suppliers = new SelectList(_context.Suppliers, "Id", "Name");
            ViewBag.Products = _context.Products.ToList();
            return View(import);
        }

        // GET: Import/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var import = await _context.Imports.FindAsync(id);
            if (import == null) return NotFound();

            ViewBag.Suppliers = new SelectList(_context.Suppliers, "Id", "Name", import.SupplierId);
            return View(import);
        }

        // POST: Import/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Import import)
        {
            if (id != import.Id) return NotFound();

            if (ModelState.IsValid)
            {
                _context.Update(import);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Suppliers = new SelectList(_context.Suppliers, "Id", "Name", import.SupplierId);
            return View(import);
        }

        // GET: Import/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var import = await _context.Imports
                .Include(i => i.Supplier)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (import == null) return NotFound();

            return View(import);
        }

        // POST: Import/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var import = await _context.Imports.FindAsync(id);
            if (import != null)
            {
                _context.Imports.Remove(import);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}