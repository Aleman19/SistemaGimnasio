using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaGimnasioV2.Data;
using SistemaGimnasioV2.Models;

namespace SistemaGimnasioV2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientController : ControllerBase
    {
        private readonly GymDbContext _dbContext;

        public ClientController(GymDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // GET: api/Client
        [HttpGet]
        public async Task<IActionResult> GetAllClients()
        {
            var clients = await _dbContext.Users
                .Where(u => u.Role == "Cliente")
                .ToListAsync();

            return Ok(clients);
        }

        // GET: api/Client/Details/5
        [HttpGet("Details/{id}")]
        public async Task<IActionResult> GetClientDetails(int id)
        {
            var client = await _dbContext.Users
                .Include(u => u.Memberships)
                .Include(u => u.Reservations)
                .FirstOrDefaultAsync(u => u.Id == id && u.Role == "Cliente");

            if (client == null)
                return NotFound($"No se encontró un cliente con ID {id}.");

            return Ok(client);
        }

        // GET: api/Client/MembershipStatus/5
        [HttpGet("MembershipStatus/{id}")]
        public async Task<IActionResult> GetMembershipStatus(int id)
        {
            var membership = await _dbContext.Memberships
                .Where(m => m.UserId == id && m.EndDate >= DateTime.Now)
                .OrderByDescending(m => m.EndDate)
                .FirstOrDefaultAsync();

            if (membership == null)
                return Ok(new { Status = "No activa", DaysRemaining = 0 });

            return Ok(new
            {
                membership.PlanName,
                membership.EndDate,
                DaysRemaining = (membership.EndDate - DateTime.Now).Days
            });
        }

        // POST: api/Client/RenewMembership
        [HttpPost("RenewMembership")]
        public async Task<IActionResult> RenewMembership([FromBody] RenewMembershipRequest request)
        {
            if (request == null || request.UserId <= 0)
                return BadRequest("Solicitud no válida.");

            var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Id == request.UserId && u.Role == "Cliente");

            if (user == null)
                return NotFound("Cliente no encontrado.");

            // Validar membresía activa
            var activeMembership = await _dbContext.Memberships
                .Where(m => m.UserId == request.UserId && m.EndDate >= DateTime.Now)
                .OrderByDescending(m => m.EndDate)
                .FirstOrDefaultAsync();

            // Fecha de inicio y final de la nueva membresía
            DateTime startDate = activeMembership?.EndDate > DateTime.Now
                ? activeMembership.EndDate.AddDays(1)
                : DateTime.Now;

            var newMembership = new Membership
            {
                UserId = request.UserId,
                PlanName = request.PlanName,
                StartDate = startDate,
                EndDate = startDate.AddMonths(request.DurationInMonths),
                Price = request.Price,
                IsPaid = true
            };

            _dbContext.Memberships.Add(newMembership);
            await _dbContext.SaveChangesAsync();

            return Ok(new { message = "Membresía renovada exitosamente.", newMembership });
        }

        // DELETE: api/Client/Delete/5
        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> DeleteClient(int id)
        {
            var client = await _dbContext.Users
                .FirstOrDefaultAsync(u => u.Id == id && u.Role == "Cliente");

            if (client == null)
                return NotFound("Cliente no encontrado.");

            _dbContext.Users.Remove(client);
            await _dbContext.SaveChangesAsync();

            return Ok($"Cliente con ID {id} eliminado.");
        }
    }

    // Modelo para la renovación de membresías
    public class RenewMembershipRequest
    {
        public int UserId { get; set; }
        public string PlanName { get; set; } = string.Empty;
        public int DurationInMonths { get; set; }
        public decimal Price { get; set; }
    }
}
