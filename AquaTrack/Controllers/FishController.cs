using AquaTrack.Data;
using AquaTrack.Models;
using AquaTrack.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AquaTrack.Controllers
{
    public class FishController : Controller
    {
        private readonly AquariumContext _context;
        private readonly IFishService _fishService;

        public FishController(AquariumContext context, IFishService fishService)
        {
            _context = context;
            _fishService = fishService;
        }

        public async Task<IActionResult> Index()
        {
            var fishList = await _context.Fish
                .Include(f => f.Tank)
                .ToListAsync();

            return View(fishList);
        }

        public async Task<IActionResult> Details(int id)
        {
            var fish = await _context.Fish
                .Include(f => f.Tank)
                .FirstOrDefaultAsync(f => f.Id == id);

            if (fish == null)
            {
                return NotFound();
            }

            ViewBag.AgeInMonths = _fishService.CalculateFishAgeInMonths(fish);
            ViewBag.IsTooBig = _fishService.IsFishTooBigForTank(fish, fish.Tank);

            return View(fish);
        }

        public IActionResult Create()
        {
            ViewBag.Tanks = _context.Tanks.ToList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Fish fish)
        {
            if (ModelState.IsValid)
            {
                _context.Add(fish);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Tanks = _context.Tanks.ToList();
            return View(fish);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var fish = await _context.Fish.FindAsync(id);
            if (fish == null)
            {
                return NotFound();
            }

            ViewBag.Tanks = _context.Tanks.ToList();
            return View(fish);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Fish fish)
        {
            if (id != fish.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(fish);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.Fish.Any(e => e.Id == fish.Id))
                        return NotFound();
                    else
                        throw;
                }

                return RedirectToAction(nameof(Index));
            }

            ViewBag.Tanks = _context.Tanks.ToList();
            return View(fish);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var fish = await _context.Fish
                .Include(f => f.Tank)
                .FirstOrDefaultAsync(f => f.Id == id);

            if (fish == null)
            {
                return NotFound();
            }

            return View(fish);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var fish = await _context.Fish.FindAsync(id);
            if (fish != null)
            {
                _context.Fish.Remove(fish);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
