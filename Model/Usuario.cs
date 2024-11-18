namespace Model
{
    public class Usuario
    {
        public string Id { get; set; }
        public string NombreUsuario { get; set; } // Asegúrate de que esta propiedad existe
        public string Contraseña { get; set; }
        public string Rol { get; set; }
    }
}
