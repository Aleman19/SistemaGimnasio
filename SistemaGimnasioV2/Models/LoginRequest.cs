
namespace SistemaGimnasioV2.Models
{
    public class LoginRequest
    {
        public string Username { get; set; } = string.Empty; // Asegura que no sea nulo
        public string Password { get; set; } = string.Empty; // Asegura que no sea nulo
    }
}