using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaGimnasioV2.Data;
using SistemaGimnasioV2.Models;

namespace SistemaGimnasioV2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClassController : ControllerBase
    {
        private readonly GymDbContext _dbContext;

        public ClassController(GymDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // GET: api/Class
        [HttpGet]
        public async Task<IActionResult> GetClasses()
        {
            try
            {
                var classes = await _dbContext.Classes.ToListAsync();
                return Ok(classes);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al obtener las clases: {ex.Message}");
            }
        }

        // GET: api/Class/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetClassById(int id)
        {
            try
            {
                var classItem = await _dbContext.Classes
                    .Include(c => c.Schedules) // Incluir horarios
                    .FirstOrDefaultAsync(c => c.Id == id);

                if (classItem == null)
                    return NotFound(new { message = $"No se encontró una clase con el ID {id}." });

                return Ok(classItem);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al obtener la clase: {ex.Message}");
            }
        }

        // POST: api/Class/AddSchedule
        [HttpPost("AddSchedule")]
        public async Task<IActionResult> AddScheduleToClass([FromBody] ClassSchedule newSchedule)
        {
            if (newSchedule == null || !ModelState.IsValid)
                return BadRequest(new { message = "Datos de horario inválidos." });

            try
            {
                // Verificar que la clase existe
                var classExists = await _dbContext.Classes.AnyAsync(c => c.Id == newSchedule.ClassId);
                if (!classExists)
                    return NotFound(new { message = $"No se encontró una clase con el ID {newSchedule.ClassId}." });

                await _dbContext.ClassSchedules.AddAsync(newSchedule);
                await _dbContext.SaveChangesAsync();

                return Ok(new { message = "Horario agregado correctamente.", schedule = newSchedule });
            }
            catch (DbUpdateException dbEx)
            {
                return StatusCode(500, $"Error al agregar el horario: {dbEx.InnerException?.Message ?? dbEx.Message}");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error inesperado: {ex.Message}");
            }
        }

        // GET: api/Class/Schedules/5
        [HttpGet("Schedules/{classId}")]
        public async Task<IActionResult> GetClassSchedules(int classId)
        {
            try
            {
                var schedules = await _dbContext.ClassSchedules
                    .Where(s => s.ClassId == classId)
                    .ToListAsync();

                if (!schedules.Any())
                    return NotFound(new { message = $"No se encontraron horarios para la clase con ID {classId}." });

                return Ok(schedules);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al obtener los horarios: {ex.Message}");
            }
        }
    }
}
