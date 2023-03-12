using MEHR.Contexts;
using MEHR.Models;
using MEHR.Views.FoodLocations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MEHR.Controllers.admin
{
    [Route("admin/FoodLocations")]
    public class FoodLocationsController : Controller
    {
        private readonly DataContext _context;

        public FoodLocationsController(DataContext context)
        {
            _context = context;
        }

        // GET: FoodLocations
        [HttpGet]
        [ActionName("Index")]
        public async Task<IActionResult> Index()
        {
              return _context.FoodLocations != null ? 
                          View(await _context.FoodLocations.ToListAsync()) :
                          Problem("Entity set 'DataContext.FoodLocations'  is null.");
        }

        // GET: FoodLocations/Details/5
        [HttpGet]
        [Route("Details/{id}")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.FoodLocations == null)
            {
                return NotFound();
            }

            var foodLocation = await _context.FoodLocations
                .FirstOrDefaultAsync(m => m.Id == id);
            if (foodLocation == null)
            {
                return NotFound();
            }

            return View(foodLocation);
        }

        // GET: FoodLocations/Create
        [HttpGet]
        [Route("Create")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: FoodLocations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create([Bind("LocationLatitude,LocationLongitude,Icon,Name,Description,PhoneNumber,HasDelivery")] CreateRecord foodLocation)
        {
            var lol = foodLocation.GetType();
            if (ModelState.IsValid)
            {
                _context.Add(new FoodLocation()
                {
                     Description = foodLocation.Description,
                     Name = foodLocation.Name,
                     PhoneNumber = foodLocation.PhoneNumber,
                     LocationLatitude = double.Parse(foodLocation.LocationLatitude),
                     LocationLongitude = double.Parse(foodLocation.LocationLongitude),
                     HasDelivery = foodLocation.HasDelivery == "on",
                     Icon = int.Parse(foodLocation.Icon)
                });
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(foodLocation);
        }

        // GET: FoodLocations/Edit/5
        [HttpGet]
        [Route("Edit/{id}")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.FoodLocations == null)
            {
                return NotFound();
            }

            var foodLocation = await _context.FoodLocations.FindAsync(id);
            if (foodLocation == null)
            {
                return NotFound();
            }
            return View(foodLocation);
        }

        // POST: FoodLocations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Route("Edit/{id}")]
        [ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,LocationLatitude,LocationLongitude,Icon,Name,Description,PhoneNumber,HasDelivery,OpeningTimesSerial")] FoodLocation foodLocation)
        {
            if (id != foodLocation.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(foodLocation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!(_context.FoodLocations?.Any(e => e.Id == foodLocation.Id)).GetValueOrDefault())
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
            return View(foodLocation);
        }

        // GET: FoodLocations/Delete/5
        [HttpGet]
        [Route("Delete/{id}")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.FoodLocations == null)
            {
                return NotFound();
            }

            var foodLocation = await _context.FoodLocations
                .FirstOrDefaultAsync(m => m.Id == id);
            if (foodLocation == null)
            {
                return NotFound();
            }

            return View(foodLocation);
        }

        // POST: FoodLocations/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        [Route("Delete/{id}" )]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.FoodLocations == null)
            {
                return Problem("Entity set 'DataContext.FoodLocations'  is null.");
            }
            var foodLocation = await _context.FoodLocations.FindAsync(id);
            if (foodLocation != null)
            {
                _context.FoodLocations.Remove(foodLocation);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
