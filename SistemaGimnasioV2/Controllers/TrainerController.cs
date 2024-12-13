using GestiónGimnasioMVC.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaGimnasioV2.Model;
namespace GestiónGimnasioMVC.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TrainerController : ControllerBase
    {
        private readonly GymDbContext _context;

        public TrainerController(GymDbContext context)
        {
            _context = context;
        }

        [HttpGet("classes")]
        public async Task<IActionResult> GetTrainerClasses(int trainerId)
        {
            var classes = await _context.Classes
                .Where(c => c.TrainerId == trainerId)
                .ToListAsync();

            if (!classes.Any())
            {
                return NotFound(new { message = "El entrenador no tiene clases asignadas" });
            }

            return Ok(classes);
        }

        [HttpPost("schedules")]
        public async Task<IActionResult> AddTrainerSchedule([FromBody] ClassSchedule schedule)
        {
            _context.ClassSchedules.Add(schedule);
            await _context.SaveChangesAsync();
            return Ok(new { message = "Horario agregado exitosamente", schedule });
        }

        [HttpGet("clients")]
        public async Task<IActionResult> GetClientsInClass(int classId)
        {
            var clients = await _context.Reservations
                .Include(r => r.Client)
                .Where(r => r.ClassId == classId)
                .Select(r => r.Client)
                .ToListAsync();

            if (!clients.Any())
            {
                return NotFound(new { message = "No hay clientes inscritos en esta clase" });
            }

            return Ok(clients);
        }
    }
}
