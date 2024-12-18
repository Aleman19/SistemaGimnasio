using Microsoft.AspNetCore.Mvc;
using SistemaGimnasioV2.Data;
using SistemaGimnasioV2.Models;

namespace SistemaGimnasioV2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AdminController : ControllerBase
    {
        private readonly GymDbContext _dbContext;

        public AdminController(GymDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // GET: api/Admin/Users
        [HttpGet("Users")]
        public IActionResult GetUsers()
        {
            var users = _dbContext.Users.ToList();
            return Ok(users);
        }

        // POST: api/Admin/AddUser
        [HttpPost("AddUser")]
        public IActionResult AddUser([FromBody] User newUser)
        {
            if (newUser == null)
                return BadRequest("Datos del usuario no válidos.");

            _dbContext.Users.Add(newUser);
            _dbContext.SaveChanges();

            return Ok(newUser);
        }

        // DELETE: api/Admin/DeleteUser/5
        [HttpDelete("DeleteUser/{id}")]
        public IActionResult DeleteUser(int id)
        {
            var user = _dbContext.Users.FirstOrDefault(u => u.Id == id);
            if (user == null)
                return NotFound("Usuario no encontrado.");

            _dbContext.Users.Remove(user);
            _dbContext.SaveChanges();

            return Ok($"Usuario con ID {id} eliminado.");
        }
    }
}
