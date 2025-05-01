using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SergioMasin.Models;
using System.Linq;
using System.Threading.Tasks;

namespace SergioMasin.Controllers
{
    public class DuenoController : Controller
    {
        private readonly SQLServer_SergioMasin _context;

        public DuenoController(SQLServer_SergioMasin context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Dueno.ToListAsync());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Edad,Tarifa,TieneMascota,FechaRegistro")] Dueno dueno)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dueno);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dueno);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dueno = await _context.Dueno.FindAsync(id);
            if (dueno == null)
            {
                return NotFound();
            }
            return View(dueno);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Edad,Tarifa,TieneMascota,FechaRegistro")] Dueno dueno)
        {
            if (id != dueno.Id)
            {
                return NotFound();
            }

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
            return View(dueno);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dueno = await _context.Dueno
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dueno == null)
            {
                return NotFound();
            }

            return View(dueno);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dueno = await _context.Dueno.FindAsync(id);
            if (dueno != null)
            {
                _context.Dueno.Remove(dueno);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DuenoExists(int id)
        {
            return _context.Dueno.Any(e => e.Id == id);
        }
    }
}


