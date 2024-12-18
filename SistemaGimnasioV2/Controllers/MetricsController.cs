using Microsoft.AspNetCore.Mvc;
using SistemaGimnasioV2.Data;
using SistemaGimnasioV2.Models;

[ApiController]
[Route("api/[controller]")]
public class MetricsController : ControllerBase
{
    private readonly GymDbContext _dbContext;

    public MetricsController(GymDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    // GET: api/Metrics/Client/5
    [HttpGet("Client/{clientId}")]
    public IActionResult GetMetricsByClient(int clientId)
    {
        var metrics = _dbContext.Metrics.Where(m => m.UserId == clientId).ToList();
        if (!metrics.Any())
            return NotFound("No se encontraron métricas para este cliente.");

        return Ok(metrics);
    }

    // POST: api/Metrics/Add
    [HttpPost("Add")]
    public IActionResult AddMetric([FromBody] ProgressMetric newMetric)
    {
        if (newMetric == null)
            return BadRequest("Datos de la métrica no válidos.");

        _dbContext.Metrics.Add(newMetric);
        _dbContext.SaveChanges();

        return Ok(newMetric);
    }
}
