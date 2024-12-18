using Microsoft.AspNetCore.Mvc;
using SistemaGimnasioV2.Data;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly GymDbContext _dbContext;

    public AuthController(GymDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    [HttpPost("Login")]
    public IActionResult Login([FromBody] LoginRequest request)
    {
        try
        {
            var user = _dbContext.Users
                .FirstOrDefault(u => u.Username == request.Username && u.Password == request.Password);

            if (user == null)
            {
                return Unauthorized("Credenciales incorrectas.");
            }

            // Simula un token o información adicional que quieras retornar
            return Ok(new
            {
                Message = "Inicio de sesión exitoso.",
                User = new { user.Id, user.Username, user.Role }
            });
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Error inesperado: {ex.Message}");
        }
    }
}

public class LoginRequest
{
    public string Username { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}
