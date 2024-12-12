using Microsoft.AspNetCore.Mvc;
using SistemaGimnasioV2.Model;
using Microsoft.EntityFrameworkCore;

namespace GestiónGimnasioMVC.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClassController : ControllerBase
    {
        private readonly GymDbContext _context;

        public ClassController(GymDbContext context) { _context = context; }
        [HttpGet]
        public async Task<IActionResult> GetAllClasses()
        {
            var classes = await _context.Classes.Include(c => c.Trainer).ToListAsync();
            return Ok(classes);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetClassById(int id)
        {
            var gymClass = await _context.Classes.Include(c => c.Trainer).FirstOrDefaultAsync(c => c.Id == id);
            if (gymClass == null) return NotFound(new { message = "Clase no encontrada" });

            return Ok(gymClass);
        }
        [HttpPost]
        public async Task<IActionResult> CreateClass([FromBody] Class gymClass)
        {
            if (gymClass == null) return BadRequest(new { message = "Datos de clase no válidos" });

            _context.Classes.Add(gymClass); await _context.SaveChangesAsync();
            return Ok(new { message = "Clase creada exitosamente", gymClass });
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateClass(int id, [FromBody] Class updatedClass)
        {
            var gymClass = await _context.Classes.FindAsync(id);
            if (gymClass == null) return NotFound(new { message = "Clase no encontrada" });

            gymClass.Name = updatedClass.Name;
            gymClass.Description = updatedClass.Description;
            gymClass.TrainerId = updatedClass.TrainerId;
            gymClass.Schedule = updatedClass.Schedule;

            await _context.SaveChangesAsync();
            return Ok(new { message = "Clase actualizada exitosamente" });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClass(int id)
        {
            var gymClass = await _context.Classes.FindAsync(id);
            if (gymClass == null) return NotFound(new { message = "Clase no encontrada" });

            _context.Classes.Remove(gymClass);
            await _context.SaveChangesAsync();
            return Ok(new { message = "Clase eliminada exitosamente" });
        }
    }
}