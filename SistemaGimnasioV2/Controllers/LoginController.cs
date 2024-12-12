using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class LoginController : ControllerBase
{
    private readonly GymDbContext _context;

    public LoginController(GymDbContext context)
    {
        _context = context;
    }

    [HttpPost]
    public IActionResult Login([FromBody] LoginRequest request)
    {
        var user = _context.Users.FirstOrDefault(u => u.Cedula == request.Cedula && u.Password == request.Password);

        if (user == null)
            return Unauthorized(new { message = "Credenciales inválidas" });

        return Ok(new { Role = user.Role, Message = "Login exitoso" });
    }
}
