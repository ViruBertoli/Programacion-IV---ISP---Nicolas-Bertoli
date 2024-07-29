using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PlanCanjeWeb.Data;
using PlanCanjeWeb.Models;
using System.Linq;
using System.Threading.Tasks;

namespace PlanCanjeWeb.Controllers
{
    [Authorize]
    public class EquipoafectadoesController : Controller
    {
        private readonly BasedatosCanje _context;

        public EquipoafectadoesController(BasedatosCanje context)
        {
            _context = context;
        }

       
        public async Task<IActionResult> Index(string searchString)
        {
            ViewData["CurrentFilter"] = searchString;

            var equipoafectados = from e in _context.Equipoafectados
                                  select e;

            if (!string.IsNullOrEmpty(searchString))
            {
                equipoafectados = equipoafectados.Where(e => e.Cliente.Contains(searchString) ||
                                                             e.ModeloDrive.Contains(searchString) ||
                                                             e.NumeroSerie.Contains(searchString) ||
                                                             e.FechaFabricacion.Contains(searchString) ||
                                                             e.FallaDeclarada.Contains(searchString) ||
                                                             e.CorreoElectronico.Contains(searchString));
            }

            return View(await equipoafectados.ToListAsync());
        }

       
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var equipoafectado = await _context.Equipoafectados
                .FirstOrDefaultAsync(m => m.Id == id);
            if (equipoafectado == null)
            {
                return NotFound();
            }

            return View(equipoafectado);
        }

       
        public IActionResult Create()
        {
            return View();
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Cliente,ModeloDrive,NumeroSerie,FechaFabricacion,FallaDeclarada,CorreoElectronico")] Equipoafectado equipoafectado)
        {
            if (ModelState.IsValid)
            {
                _context.Add(equipoafectado);
                await _context.SaveChangesAsync();
                TempData["SuccessMessage"] = "Equipo registrado con éxito.";
                return RedirectToAction("Index", "Home");
            }
            return View(equipoafectado);
        }

       
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var equipoafectado = await _context.Equipoafectados.FindAsync(id);
            if (equipoafectado == null)
            {
                return NotFound();
            }
            return View(equipoafectado);
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Cliente,ModeloDrive,NumeroSerie,FechaFabricacion,FallaDeclarada,CorreoElectronico")] Equipoafectado equipoafectado)
        {
            if (id != equipoafectado.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(equipoafectado);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EquipoafectadoExists(equipoafectado.Id))
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
            return View(equipoafectado);
        }

       
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var equipoafectado = await _context.Equipoafectados
                .FirstOrDefaultAsync(m => m.Id == id);
            if (equipoafectado == null)
            {
                return NotFound();
            }

            return View(equipoafectado);
        }

       
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var equipoafectado = await _context.Equipoafectados.FindAsync(id);
            _context.Equipoafectados.Remove(equipoafectado);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EquipoafectadoExists(int id)
        {
            return _context.Equipoafectados.Any(e => e.Id == id);
        }
    }
}
