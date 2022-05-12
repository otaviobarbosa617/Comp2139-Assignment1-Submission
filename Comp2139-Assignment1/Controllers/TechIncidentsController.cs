#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GBCSporting_OJO.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace GBCSporting_OJO.Controllers
{
    public class TechIncidentsController : Controller
    {
        private readonly GBCSporting_OJOContext _context;

        public TechIncidentsController(GBCSporting_OJOContext context)
        {
            _context = context;
        }

        // GET: Incidents
        [Route("Techincident/List")]
        public async Task<IActionResult> Index()
        {
            //Only incidents without a closedate
            var comp2139_Assignment1Context = _context.Incidents.Include(i => i.Customer).Include(i => i.Product).Include(i => i.Technician).Where(i => i.IncidentDateClosed == null);
            return View(await comp2139_Assignment1Context.ToListAsync());
        }



        // GET: Incidents/Edit/5
        public async Task<IActionResult> Edit(int? id)
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

        private bool IncidentExists(int id)
        {
            return _context.Incidents.Any(e => e.IncidentId == id);
        }
    }
}
