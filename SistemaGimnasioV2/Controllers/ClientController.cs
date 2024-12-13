using GestiónGimnasioMVC.Data;
using GestiónGimnasioMVC.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GestiónGimnasioMVC.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientController : ControllerBase
    {
        private readonly GymDbContext _context;

        public ClientController(GymDbContext context)
        {
            _context = context;
        }

        [HttpGet("{id}/metrics")]
        public async Task<IActionResult> GetMetrics(int id)
        {
            var metrics = await _context.ProgressMetrics
                .Where(m => m.ClientId == id)
                .ToListAsync();

            return Ok(metrics);
        }

        [HttpPost("{id}/metrics")]
        public async Task<IActionResult> AddMetrics(int id, [FromBody] ProgressMetric metric)
        {
            metric.ClientId = id;
            _context.ProgressMetrics.Add(metric);
            await _context.SaveChangesAsync();
            return Ok(new { message = "Métricas agregadas exitosamente", metric });
        }

        [HttpPut("metrics/{id}")]
        public async Task<IActionResult> UpdateMetrics(int id, [FromBody] ProgressMetric updatedMetric)
        {
            var metric = await _context.ProgressMetrics.FindAsync(id);
            if (metric == null) return NotFound(new { message = "Métrica no encontrada" });

            metric.Value = updatedMetric.Value;
            metric.Date = updatedMetric.Date;

            await _context.SaveChangesAsync();
            return Ok(new { message = "Métrica actualizada exitosamente" });
        }
    }
}
