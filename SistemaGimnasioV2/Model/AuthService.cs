using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace GestiónGimnasioMVC.Services
{
    public class AuthService // No debe ser estática
    {
        private readonly IHttpContextAccessor _contextAccessor;

        public AuthService(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }

        // Método para iniciar sesión
        public async Task SignInAsync(string cedula, string role)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, cedula),
                new Claim(ClaimTypes.Role, role)
            };

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            await _contextAccessor.HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity));
        }

        // Método para cerrar sesión
        public async Task SignOutAsync()
        {
            await _contextAccessor.HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        }

        // Método para obtener el rol actual
        public string? GetCurrentUserRole()
        {
            return _contextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.Role)?.Value;
        }
    }
}
