using GestiónGimnasioMVC.Data;
using GestiónGimnasioMVC.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GestiónGimnasioMVC.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MembershipController : ControllerBase
    {
        private readonly GymDbContext _context;

        public MembershipController(GymDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllMemberships()
        {
            var memberships = await _context.Memberships.Include(m => m.Client).ToListAsync();
            return Ok(memberships);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMembershipById(int id)
        {
            var membership = await _context.Memberships.Include(m => m.Client).FirstOrDefaultAsync(m => m.Id == id);
            if (membership == null) return NotFound(new { message = "Membresía no encontrada" });

            return Ok(membership);
        }

        [HttpPost]
        public async Task<IActionResult> CreateMembership([FromBody] Membership membership)
        {
            if (membership == null) return BadRequest(new { message = "Datos de membresía no válidos" });

            _context.Memberships.Add(membership);
            await _context.SaveChangesAsync();
            return Ok(new { message = "Membresía creada exitosamente", membership });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMembership(int id, [FromBody] Membership updatedMembership)
        {
            var membership = await _context.Memberships.FindAsync(id);
            if (membership == null) return NotFound(new { message = "Membresía no encontrada" });

            membership.Type = updatedMembership.Type;
            membership.StartDate = updatedMembership.StartDate;
            membership.EndDate = updatedMembership.EndDate;
            membership.Cost = updatedMembership.Cost;

            await _context.SaveChangesAsync();
            return Ok(new { message = "Membresía actualizada exitosamente" });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMembership(int id)
        {
            var membership = await _context.Memberships.FindAsync(id);
            if (membership == null) return NotFound(new { message = "Membresía no encontrada" });

            _context.Memberships.Remove(membership);
            await _context.SaveChangesAsync();
            return Ok(new { message = "Membresía eliminada exitosamente" });
        }
    }
}
