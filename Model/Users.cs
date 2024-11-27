using System;

namespace Models
{
    public class User
    {
        public int ID { get; set; }
        public string Nombre { get; set; } = string.Empty; // Predeterminado para evitar null
        public string Apellido { get; set; } = string.Empty; // Predeterminado
        public string Email { get; set; } = string.Empty; // Predeterminado
        public string Username { get; set; } = string.Empty; // Predeterminado
        public string Password { get; set; } = string.Empty; // Predeterminado
    }
}
