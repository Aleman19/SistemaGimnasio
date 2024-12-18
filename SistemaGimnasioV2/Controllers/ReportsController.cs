using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaGimnasioV2.Data;

namespace SistemaGimnasioV2.Controllers
{
    [ApiController]
    [Route("api/reports")]
    public class ReportsController : ControllerBase
    {
        private readonly GymDbContext _context;

        public ReportsController(GymDbContext context)
        {
            _context = context;
        }

        [HttpGet("ingresos")]
        public async Task<IActionResult> GetIngresosReport()
        {
            var ingresos = await _context.Invoices
                .GroupBy(i => new { i.Date.Year, i.Date.Month })
                .Select(g => new
                {
                    Mes = g.Key.Month,
                    Año = g.Key.Year,
                    Total = g.Sum(i => i.Amount)
                })
                .ToListAsync();

            return Ok(ingresos);
        }

        [HttpGet("actividad")]
        public async Task<IActionResult> GetActividadReport()
        {
            var actividad = await _context.Reservations
                .GroupBy(r => r.UserId)
                .Select(g => new
                {
                    Usuario = g.Key,
                    TotalClases = g.Count()
                })
                .ToListAsync();

            return Ok(actividad);
        }
    }
}
