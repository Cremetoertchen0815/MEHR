using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MEHR.Contexts;
using MEHR.Models;

namespace MEHR.Controllers.admin
{
	[ApiExplorerSettings(IgnoreApi = false)]
	[Route("admin/[controller]")]
	public class AppUsersController : Controller
	{
		private readonly DataContext _context;

		public AppUsersController(DataContext context)
		{
			_context = context;
		}

		// GET: AppUsers
		[HttpGet]
		public async Task<IActionResult> Index()
		{
			return _context.Users != null ?
						View(await _context.Users.Include(x => x.Ratings).Include(x => x.History).ToListAsync()) :
						Problem("Entity set 'DataContext.Users'  is null.");
		}

		// GET: AppUsers/Details/5
		[HttpGet("Details/{id}")]
		public async Task<IActionResult> Details(int? id)
		{
			if (id == null || _context.Users == null)
			{
				return NotFound();
			}

			var appUser = await _context.Users.Include(x => x.Ratings!).ThenInclude(x => x.Location).Include(x => x.History)
				.FirstOrDefaultAsync(m => m.Id == id);
			if (appUser == null)
			{
				return NotFound();
			}

			return View(appUser);
		}

		// GET: AppUsers/Create
		[HttpGet("Create")]
		public IActionResult Create() => View();

		// POST: AppUsers/Create
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost("Create")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create([Bind("Id,CookieHash")] AppUser appUser)
		{
			if (ModelState.IsValid)
			{
				_context.Add(appUser);
				await _context.SaveChangesAsync();
				return RedirectToAction(nameof(Index));
			}
			return View(appUser);
		}

		// GET: AppUsers/Edit/5
		[HttpGet("Edit/{id}")]
		public async Task<IActionResult> Edit(int? id)
		{
			if (id == null || _context.Users == null)
			{
				return NotFound();
			}

			var appUser = await _context.Users.Include(x => x.Ratings!).ThenInclude(x => x.Location).Include(x => x.History).FirstOrDefaultAsync(x => x.Id == id);
			if (appUser == null)
			{
				return NotFound();
			}
			return View(appUser);
		}

		// POST: AppUsers/Edit/5
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost("Edit/{id}")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(int id, Dictionary<string, string> parameters)
		{

			try
			{
				var appUser = await _context.Users.Include(x => x.Ratings!).ThenInclude(x => x.Location).Include(x => x.History).FirstOrDefaultAsync(x => x.Id == id) ?? throw new Exception();
				_context.Update(appUser);
				await _context.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!AppUserExists(id))
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

		// GET: AppUsers/Delete/5
		[HttpGet("Delete/{id}")]
		public async Task<IActionResult> Delete(int? id)
		{
			if (id == null || _context.Users == null)
			{
				return NotFound();
			}

			var appUser = await _context.Users
				.FirstOrDefaultAsync(m => m.Id == id);
			if (appUser == null)
			{
				return NotFound();
			}

			return View(appUser);
		}

		// POST: AppUsers/Delete/5
		[HttpPost("Delete/{id}")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteConfirmed(int id)
		{
			if (_context.Users == null)
			{
				return Problem("Entity set 'DataContext.Users'  is null.");
			}
			var appUser = await _context.Users.FindAsync(id);
			if (appUser != null)
			{
				_context.Users.Remove(appUser);
			}

			await _context.SaveChangesAsync();
			return RedirectToAction(nameof(Index));
		}

		private bool AppUserExists(int id)
		{
			return (_context.Users?.Any(e => e.Id == id)).GetValueOrDefault();
		}
	}
}
