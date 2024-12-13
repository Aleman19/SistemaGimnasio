using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
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
            try
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
            catch (Exception ex)
            {
                // Aquí puedes registrar el error o hacer algún manejo adicional
                throw new InvalidOperationException("Error during sign-in process", ex);
            }
        }

        // Método para cerrar sesión
        public async Task SignOutAsync()
        {
            try
            {
                await _contextAccessor.HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            }
            catch (Exception ex)
            {
                // Aquí también puedes registrar el error o manejarlo
                throw new InvalidOperationException("Error during sign-out process", ex);
            }
        }

        // Método para obtener el rol actual
        public string? GetCurrentUserRole()
        {
            return _contextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.Role)?.Value;
        }
    }
}
