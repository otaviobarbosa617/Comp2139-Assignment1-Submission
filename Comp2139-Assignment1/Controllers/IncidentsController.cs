#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GBCSporting_OJO.Models;

namespace GBCSporting_OJO.Controllers
{
    public class IncidentsController : Controller
    {
        private readonly GBCSporting_OJOContext _context;

        public IncidentsController(GBCSporting_OJOContext context)
        {
            _context = context;
        }

        [Route("incidents/list")]
        // GET: Incidents
        public async Task<IActionResult> Index(string filter)
        {
            var comp2139_Assignment1Context = filter switch
            {
                "allincidents" => _context.Incidents.Include(i => i.Customer).Include(i => i.Product).Include(i => i.Technician),
                "unassigned" => _context.Incidents.Include(i => i.Customer).Include(i => i.Product).Include(i => i.Technician).Where(i => i.Technician == null),
                "openincidents" => _context.Incidents.Include(i => i.Customer).Include(i => i.Product).Include(i => i.Technician).Where(i => i.IncidentDateClosed == null),
                _ => _context.Incidents.Include(i => i.Customer).Include(i => i.Product).Include(i => i.Technician),
            };
            return View(await comp2139_Assignment1Context.ToListAsync());
        }


        // GET: Incidents/Create
        public IActionResult Create()
        {
            //Values for viewbag on incident form follow: context.model, bindId, valueToBeShowtoUser
            ViewData["CustomerId"] = new SelectList(_context.Customers, "CustomerId", "CustomerFirstName");
            ViewData["ProductId"] = new SelectList(_context.Products, "ProductId", "ProductName");
            ViewData["TechnicianId"] = new SelectList(_context.Technicians, "TechnicianId", "TechnicianName");
            return View();
        }

        // POST: Incidents/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IncidentId,CustomerId,ProductId,IncidentTitle,IncidentDescription,TechnicianId,IncidentDateOpened,IncidentDateClosed")] Incident incident)
        {

            if (ModelState.IsValid)
            {
                _context.Add(incident);
                await _context.SaveChangesAsync();
                TempData["IncidentAddName"] = incident.ToString();
                return RedirectToAction(nameof(Index));
            }
            else
            {
                //in case of error of validation, it calls back the create method with the get items
                return Create();
            }
            
        }

        // GET: Incidents/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var incident = await _context.Incidents.FindAsync(id);
            if (incident == null)
            {
                return NotFound();
            }
            ViewData["CustomerId"] = new SelectList(_context.Customers, "CustomerId", "CustomerFirstName");
            ViewData["ProductId"] = new SelectList(_context.Products, "ProductId", "ProductName");
            ViewData["TechnicianId"] = new SelectList(_context.Technicians, "TechnicianId", "TechnicianName");
            return View(incident);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IncidentId,CustomerId,ProductId,IncidentTitle,IncidentDescription,TechnicianId,IncidentDateOpened,IncidentDateClosed")] Incident incident)
        {
            if (id != incident.IncidentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(incident);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IncidentExists(incident.IncidentId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                TempData["IncidentEditName"] = incident.IncidentTitle.ToString();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CustomerId"] = new SelectList(_context.Customers, "CustomerId", "CustomerFirstName");
            ViewData["ProductId"] = new SelectList(_context.Products, "ProductId", "ProductName");
            ViewData["TechnicianId"] = new SelectList(_context.Technicians, "TechnicianId", "TechnicianName");
            return View(incident);
        }

        // GET: Incidents/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var incident = await _context.Incidents
                .Include(i => i.Customer)
                .Include(i => i.Product)
                .Include(i => i.Technician)
                .FirstOrDefaultAsync(m => m.IncidentId == id);
            if (incident == null)
            {
                return NotFound();
            }

            return View(incident);
        }

        // POST: Incidents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var incident = await _context.Incidents.FindAsync(id);
            _context.Incidents.Remove(incident);
            await _context.SaveChangesAsync();
            TempData["IncidentDeleteName"] = incident.IncidentTitle.ToString();
            return RedirectToAction(nameof(Index));
        }

        private bool IncidentExists(int id)
        {
            return _context.Incidents.Any(e => e.IncidentId == id);
        }
    }
}
