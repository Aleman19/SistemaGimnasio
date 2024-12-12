using System.ComponentModel.DataAnnotations;
namespace GestiónGimnasioMVC.Model
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(20)]
        public string Cedula { get; set; } // Número de identificación único
        [Required]
        [MaxLength(100)]
        public string Password { get; set; } // Contraseña encriptada
        [Required]
        [MaxLength(50)]
        public string Role { get; set; } // Roles: "Administrador", "Entrenador", "Cliente"
        [Required]
        [MaxLength(100)]
        public string Name { get; set; } // Nombre completo del usuario

        [MaxLength(100)]
        public string Email { get; set; } // Opcionalpublic DateTime CreatedAt { get; set; } = DateTime.Now; // Fecha de registro del usuario
    }
}