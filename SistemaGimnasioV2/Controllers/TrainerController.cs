using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaGimnasioV2.Data;
using SistemaGimnasioV2.Models;

namespace SistemaGimnasioV2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TrainerController : ControllerBase
    {
        private readonly GymDbContext _dbContext;

        public TrainerController(GymDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // GET: api/Trainer
        [HttpGet]
        public IActionResult GetAllTrainers()
        {
            var trainers = _dbContext.Users.Where(u => u.Role == "Entrenador").ToList();
            return Ok(trainers);
        }

        // GET: api/Trainer/Classes/5
        [HttpGet("Classes/{trainerId}")]
        public IActionResult GetTrainerClasses(int trainerId)
        {
            var classes = _dbContext.ClassSchedules
                .Include(c => c.Trainer)
                .Where(c => c.TrainerId == trainerId)
                .ToList();

            if (!classes.Any())
                return NotFound("No se encontraron clases asignadas a este entrenador.");

            return Ok(classes);
        }

        // POST: api/Trainer/AddClass
        [HttpPost("AddClass")]
        public IActionResult AddClass([FromBody] ClassSchedule newClassSchedule)
        {
            if (newClassSchedule == null)
                return BadRequest("Datos de la clase no válidos.");

            _dbContext.ClassSchedules.Add(newClassSchedule);
            _dbContext.SaveChanges();

            return Ok(newClassSchedule);
        }

        // GET: api/Trainer/Clients/5
        [HttpGet("Clients/{trainerId}")]
        public IActionResult GetClientsByTrainer(int trainerId)
        {
            var clients = _dbContext.Users
                .Where(u => u.TrainerId == trainerId && u.Role == "Cliente")
                .ToList();

            if (!clients.Any())
                return NotFound("No se encontraron clientes asignados a este entrenador.");

            return Ok(clients);
        }

        // DELETE: api/Trainer/DeleteClass/5
        [HttpDelete("DeleteClass/{classId}")]
        public IActionResult DeleteClass(int classId)
        {
            var classSchedule = _dbContext.ClassSchedules.FirstOrDefault(c => c.Id == classId);

            if (classSchedule == null)
                return NotFound("Clase no encontrada.");

            _dbContext.ClassSchedules.Remove(classSchedule);
            _dbContext.SaveChanges();

            return Ok($"Clase con ID {classId} eliminada.");
        }
    }
}
