using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GBCSporting_OJO.Models;

namespace GBCSporting_OJO.Controllers
{
    public class TechniciansController : Controller
    {
        private readonly GBCSporting_OJOContext _context;

        public TechniciansController(GBCSporting_OJOContext context)
        {
            _context = context;
        }


        // GET: Technicians
        [Route("Technicians/List")]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Technicians.ToListAsync());
        }

        // GET: Technicians/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Technicians/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TechnicianId,TechnicianName,TechnicianEmail,TechnicianPhone")] Technicians technicians)
        {
            if (ModelState.IsValid)
            {
                _context.Add(technicians);
                await _context.SaveChangesAsync();
                TempData["TechAddName"] = technicians.TechnicianName.ToString();
                return RedirectToAction(nameof(Index));
            }
            return View(technicians);
        }

        // GET: Technicians/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var technicians = await _context.Technicians.FindAsync(id);
            if (technicians == null)
            {
                return NotFound();
            }
            return View(technicians);
        }

        // POST: Technicians/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TechnicianId,TechnicianName,TechnicianEmail,TechnicianPhone")] Technicians technicians)
        {
            if (id != technicians.TechnicianId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(technicians);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TechniciansExists(technicians.TechnicianId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                TempData["TechEditName"] = technicians.TechnicianName.ToString();
                return RedirectToAction(nameof(Index));
            }
            return View(technicians);
        }

        // GET: Technicians/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var technicians = await _context.Technicians
                .FirstOrDefaultAsync(m => m.TechnicianId == id);
            if (technicians == null)
            {
                return NotFound();
            }

            return View(technicians);
        }

        // POST: Technicians/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var technicians = await _context.Technicians.FindAsync(id);
            _context.Technicians.Remove(technicians);
            await _context.SaveChangesAsync();
            TempData["TechDeleteName"] = technicians.TechnicianName.ToString();
            return RedirectToAction(nameof(Index));
        }

        private bool TechniciansExists(int id)
        {
            return _context.Technicians.Any(e => e.TechnicianId == id);
        }
    }
}
