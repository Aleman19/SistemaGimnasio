using System;

public class Entrenador
{
    public int IdEntrenador { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public string Apellido { get; set; } = string.Empty;
    public string Username { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Telefono { get; set; } = string.Empty;
    public DateTime FechaInicio { get; set; } = DateTime.Now; // Valor predeterminado
    public string Especialidad { get; set; } = string.Empty;
}
