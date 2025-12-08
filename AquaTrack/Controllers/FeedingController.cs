using AquaTrack.Data;
using AquaTrack.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AquaTrack.Controllers
{
    public class FeedingController : Controller
    {
        private readonly AquariumContext _context;
        private readonly ILogger<FeedingController> _logger;

        public FeedingController(AquariumContext context, ILogger<FeedingController> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<IActionResult> Create(int fishId)
        {
            var fish = await _context.Fish.FindAsync(fishId);
            if (fish == null)
            {
                _logger.LogWarning("Attempted to create feeding for missing fishId={FishId}", fishId);
                return NotFound();
            }

            return View(new Feeding { FishId = fish.Id });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Feeding feeding)
        {
            string requestId = HttpContext.TraceIdentifier;

            if (!ModelState.IsValid)
            {
                _logger.LogWarning(
                    "Feeding create failed validation for fishId={FishId}, requestId={RequestId}",
                    feeding.FishId, requestId);

                return View(feeding);
            }

            try
            {
                _context.Feedings.Add(feeding);
                await _context.SaveChangesAsync();

                _logger.LogInformation(
                    "Feeding created successfully for fishId={FishId}, food={FoodType}, fedAt={FedAt}, requestId={RequestId}",
                    feeding.FishId, feeding.FoodType, feeding.FedAt, requestId
                );

                return RedirectToAction("Details", "Fish", new { id = feeding.FishId });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex,
                    "Error while creating feeding for fishId={FishId}, requestId={RequestId}",
                    feeding.FishId, requestId);

                ModelState.AddModelError("", "Could not save feeding. Try again.");
                return View(feeding);
            }
        }
    }
}
