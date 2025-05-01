using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SergioMasin.Models;
using System.Linq;
using System.Threading.Tasks;

namespace SergioMasin.Controllers
{
    public class MascotaController : Controller
    {
        private readonly SQLServer_SergioMasin _context;

        public MascotaController(SQLServer_SergioMasin context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Mascota.ToListAsync());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Raza,Edad,FechaNacimiento,TieneVacunas")] Mascota mascota)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mascota);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(mascota);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mascota = await _context.Mascota.FindAsync(id);
            if (mascota == null)
            {
                return NotFound();
            }
            return View(mascota);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Raza,Edad,FechaNacimiento,TieneVacunas")] Mascota mascota)
        {
            if (id != mascota.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mascota);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MascotaExists(mascota.Id))
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
            return View(mascota);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mascota = await _context.Mascota
                .FirstOrDefaultAsync(m => m.Id == id);
            if (mascota == null)
            {
                return NotFound();
            }

            return View(mascota);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mascota = await _context.Mascota.FindAsync(id);
            if (mascota != null)
            {
                _context.Mascota.Remove(mascota);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MascotaExists(int id)
        {
            return _context.Mascota.Any(e => e.Id == id);
        }
    }
}


