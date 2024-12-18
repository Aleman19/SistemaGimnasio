using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaGimnasioV2.Data;
using SistemaGimnasioV2.Models;


namespace SistemaGimnasioV2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MembershipController : ControllerBase
    {
        private readonly GymDbContext _dbContext;

        public MembershipController(GymDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // GET: api/Membership
        [HttpGet]
        public IActionResult GetAllMemberships()
        {
            var memberships = _dbContext.Memberships.Include(m => m.User).ToList();
            return Ok(memberships);
        }

        // GET: api/Membership/Client/5
        [HttpGet("Client/{clientId}")]
        public IActionResult GetMembershipByClient(int clientId)
        {
            var membership = _dbContext.Memberships.Include(m => m.User).FirstOrDefault(m => m.UserId == clientId);
            if (membership == null)
                return NotFound($"No se encontró una membresía para el cliente con ID {clientId}.");

            return Ok(membership);
        }

        // POST: api/Membership/Add
        [HttpPost("Add")]
        public IActionResult AddMembership([FromBody] Membership newMembership)
        {
            if (newMembership == null)
                return BadRequest("Datos de la membresía no válidos.");

            // Validar que el usuario existe
            var user = _dbContext.Users.FirstOrDefault(u => u.Id == newMembership.UserId);
            if (user == null)
                return NotFound($"No se encontró un usuario con ID {newMembership.UserId}.");

            _dbContext.Memberships.Add(newMembership);
            _dbContext.SaveChanges();

            return Ok(newMembership);
        }

        // PUT: api/Membership/Update/5
        [HttpPut("Update/{id}")]
        public IActionResult UpdateMembership(int id, [FromBody] Membership updatedMembership)
        {
            if (updatedMembership == null)
                return BadRequest("Datos de la membresía no válidos.");

            var membership = _dbContext.Memberships.FirstOrDefault(m => m.Id == id);
            if (membership == null)
                return NotFound($"No se encontró una membresía con ID {id}.");

            membership.PlanName = updatedMembership.PlanName;
            membership.StartDate = updatedMembership.StartDate;
            membership.EndDate = updatedMembership.EndDate;
            membership.Price = updatedMembership.Price;

            _dbContext.SaveChanges();

            return Ok(membership);
        }

        // DELETE: api/Membership/Delete/5
        [HttpDelete("Delete/{id}")]
        public IActionResult DeleteMembership(int id)
        {
            var membership = _dbContext.Memberships.FirstOrDefault(m => m.Id == id);
            if (membership == null)
                return NotFound($"No se encontró una membresía con ID {id}.");

            _dbContext.Memberships.Remove(membership);
            _dbContext.SaveChanges();

            return Ok($"Membresía con ID {id} eliminada.");
        }

        // GET: api/Membership/Validate/Client/5
        [HttpGet("Validate/Client/{clientId}")]
        public IActionResult ValidateMembership(int clientId)
        {
            var membership = _dbContext.Memberships.FirstOrDefault(m => m.UserId == clientId);

            if (membership == null)
                return NotFound($"No se encontró una membresía para el cliente con ID {clientId}.");

            var isValid = membership.EndDate >= DateTime.Now;
            return Ok(new
            {
                IsValid = isValid,
                Message = isValid ? "La membresía está activa." : "La membresía ha expirado.",
                Membership = membership
            });
        }
    }
}
