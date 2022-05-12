using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GBCSporting_OJO.Models;

namespace GBCSporting_OJO.Controllers
{
    public class CustomersController : Controller
    {
        private readonly GBCSporting_OJOContext _context;

        public CustomersController(GBCSporting_OJOContext context)
        {
            _context = context;
        }

        // GET: Customers
        [Route("Customer/List")]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Customers.ToListAsync());
        }

        // GET: Customers/Create
        public IActionResult Create()
        {
            ViewData["CustomerCountry"] = new SelectList(_context.Customers, "CustomerCountry", "CustomerCountry");
            return View();
        }

        // POST: Customers/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CustomerId,CustomerFirstName,CustomerLastName,CustomerAddress,CustomerCity,CustomerState,CustomerCountry,CustomerEmail,CustomerPhone")] Customers customers)
        {
            if (ModelState.IsValid)
            {
                _context.Add(customers);
                await _context.SaveChangesAsync();
                var fName = customers.CustomerFirstName.ToString();
                var lName = customers.CustomerLastName.ToString();
                TempData["CustomerAddName"] = fName + " " + lName;
                return RedirectToAction(nameof(Index));
            }
            ViewData["CustomerCountry"] = new SelectList(_context.Customers, "CustomerCountry", "CustomerCountry");
            return View(customers);
        }

        // GET: Customers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customers = await _context.Customers.FindAsync(id);
            if (customers == null)
            {
                return NotFound();
            }
            return View(customers);
        }

        // POST: Customers/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CustomerId,CustomerFirstName,CustomerLastName,CustomerAddress,CustomerCity,CustomerState,CustomerCountry,CustomerEmail,CustomerPhone")] Customers customers)
        {
            if (id != customers.CustomerId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(customers);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CustomersExists(customers.CustomerId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                var fName = customers.CustomerFirstName.ToString();
                var lName = customers.CustomerLastName.ToString();
                TempData["CustomerEditName"] = fName + " " + lName;
                return RedirectToAction(nameof(Index));
            }
            return View(customers);
        }

        // GET: Customers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customers = await _context.Customers
                .FirstOrDefaultAsync(m => m.CustomerId == id);
            if (customers == null)
            {
                return NotFound();
            }

            return View(customers);
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var customers = await _context.Customers.FindAsync(id);
            _context.Customers.Remove(customers);
            await _context.SaveChangesAsync();
            var fName = customers.CustomerFirstName.ToString();
            var lName = customers.CustomerLastName.ToString();
            TempData["CustomerDeleteName"] = fName + " " + lName;
            return RedirectToAction(nameof(Index));
        }

        private bool CustomersExists(int id)
        {
            return _context.Customers.Any(e => e.CustomerId == id);
        }
    }
}
