using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SergioMasin.Models;

namespace SergioMasin.Controllers
{
    public class DuenoController : Controller
    {
        private readonly SQLServer_SergioMasin _context;

        public DuenoController(SQLServer_SergioMasin context)
        {
            _context = context;
        }

        // GET: Dueno
        public async Task<IActionResult> Index()
        {
            return View(await _context.Dueno.ToListAsync());
        }

        // GET: Dueno/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();

            var dueno = await _context.Dueno
                .FirstOrDefaultAsync(m => m.Id == id);

            if (dueno == null)
                return NotFound();

            return View(dueno);
        }

        // GET: Dueno/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Dueno/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Seguro,FechaVisita,Telefono")] Dueno dueno)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dueno);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dueno);
        }

        // GET: Dueno/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var dueno = await _context.Dueno.FindAsync(id);
            if (dueno == null)
                return NotFound();

            return View(dueno);
        }

        // POST: Dueno/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Seguro,FechaVisita,Telefono")] Dueno dueno)
        {
            if (id != dueno.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dueno);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DuenoExists(dueno.Id))
                        return NotFound();
                    else
                        throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(dueno);
        }

        // GET: Dueno/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var dueno = await _context.Dueno
                .FirstOrDefaultAsync(m => m.Id == id);

            if (dueno == null)
                return NotFound();

            return View(dueno);
        }

        // POST: Dueno/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dueno = await _context.Dueno.FindAsync(id);
            if (dueno != null)
                _context.Dueno.Remove(dueno);

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DuenoExists(int id)
        {
            return _context.Dueno.Any(e => e.Id == id);
        }
    }
}

