using Microsoft.AspNetCore.Mvc;
using SistemaGimnasioV2.Data;
using SistemaGimnasioV2.Models;

namespace SistemaGimnasioV2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly GymDbContext _dbContext; // Contexto para acceso a la base de datos

        public LoginController(GymDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequest request)
        {
            // Validar que se recibieron las credenciales
            if (string.IsNullOrWhiteSpace(request.Username) || string.IsNullOrWhiteSpace(request.Password))
            {
                return BadRequest("El nombre de usuario y la contraseña son requeridos.");
            }

            // Buscar al usuario en la base de datos
            var user = _dbContext.Users
                .FirstOrDefault(u => u.Username == request.Username);

            // Validar si el usuario existe y la contraseña coincide
            if (user == null || !VerifyPassword(request.Password, user.Password))
            {
                return Unauthorized("Credenciales inválidas.");
            }

            // Generar respuesta con la información del usuario
            var userResponse = new UserResponse
            {
                Message = "Inicio de sesión exitoso.",
                User = new UserResponseDetails
                {
                    Id = user.Id,
                    Username = user.Username,
                    Role = user.Role
                }
            };

            return Ok(userResponse);
        }

        // Método para verificar contraseñas
        private bool VerifyPassword(string inputPassword, string hashedPassword)
        {
            // Comparar directamente si no hay cifrado implementado
            return inputPassword == hashedPassword;
        }
    }
}
