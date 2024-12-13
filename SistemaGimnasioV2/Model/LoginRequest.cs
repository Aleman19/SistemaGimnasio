using System.ComponentModel.DataAnnotations;

namespace GestiónGimnasioMVC.Model
{
    public class LoginRequest
    {
        [Required(ErrorMessage = "El correo electrónico es obligatorio.")]
        public required string Email { get; set; }

        [Required(ErrorMessage = "La contraseña es obligatoria.")]
        public required string Password { get; set; }
    }
}


