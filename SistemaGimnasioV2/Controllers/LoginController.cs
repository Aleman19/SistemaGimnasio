﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaGimnasioV2.Models;  // Asegúrate de que este espacio de nombres esté correctamente referenciado
using GestiónGimnasioMVC.Data;

namespace SistemaGimnasioV2.Controllers
{
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
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.Cedula) || string.IsNullOrWhiteSpace(request.Password))
            {
                return BadRequest(new { message = "Cédula y contraseña son obligatorias" });
            }

            var user = await _context.Users
                .AsNoTracking()
                .FirstOrDefaultAsync(u => u.Cedula == request.Cedula && u.Password == request.Password);

            if (user == null)
            {
                return Unauthorized(new { message = "Credenciales inválidas" });
            }

            // Devuelve el rol para redirigir al usuario al dashboard correspondiente
            return Ok(new { user.Role, UserId = user.Id, Message = "Login exitoso" });
        }
    }
}
