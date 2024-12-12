public class User
{
    public int Id { get; set; }
    public string Cedula { get; set; }
    public string Password { get; set; }
    public string Role { get; set; } // "Administrador", "Entrenador", "Cliente"
}