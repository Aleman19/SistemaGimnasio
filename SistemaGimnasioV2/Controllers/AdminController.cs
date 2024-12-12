using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;

namespace GestiónGimnasioMVC.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AdminController : ControllerBase
    {
        private readonly GymDbContext _context;

        public AdminController(GymDbContext context)
        {
            _context = context;
        }

        [HttpGet("users")]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _context.Users.ToListAsync();
            return Ok(users);
        }

        [HttpPost("users")]
        public async Task<IActionResult> AddUser([FromBody] User user)
        {
            if (string.IsNullOrWhiteSpace(user.Cedula) || string.IsNullOrWhiteSpace(user.Password))
            {
                return BadRequest(new { message = "Cédula y contraseña son obligatorias" });
            }

            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return Ok(new { message = "Usuario agregado exitosamente", user });
        }

        [HttpPut("users/{id}")]
        public async Task<IActionResult> UpdateUser(int id, [FromBody] User user)
        {
            var existingUser = await _context.Users.FindAsync(id);
            if (existingUser == null) return NotFound(new { message = "Usuario no encontrado" });

            existingUser.Cedula = user.Cedula;
            existingUser.Password = user.Password;
            existingUser.Role = user.Role;

            await _context.SaveChangesAsync();
            return Ok(new { message = "Usuario actualizado exitosamente" });
        }

        [HttpDelete("users/{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null) return NotFound(new { message = "Usuario no encontrado" });

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return Ok(new { message = "Usuario eliminado exitosamente" });
        }
    }
}
