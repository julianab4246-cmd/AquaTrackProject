using AquaTrack.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AquaTrack.Controllers
{
    [Route("healthz")]
    public class DiagnosticsController : Controller
    {
        private readonly AquariumContext _context;

        public DiagnosticsController(AquariumContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> HealthCheck()
        {
            var result = new Dictionary<string, object>();
            result["applicationStatus"] = "OK";

            try
            {
                await _context.Database.ExecuteSqlRawAsync("SELECT 1");
                result["database"] = new { status = "OK" };
            }
            catch (Exception ex)
            {
                result["database"] = new { status = "ERROR", message = ex.Message };
                return StatusCode(503, result);
            }

            result["timestamp"] = DateTime.UtcNow;
            return Ok(result);
        }
    }
}
