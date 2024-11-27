public class Cliente
{
    public int IdCliente { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public string Apellido { get; set; } = string.Empty;
    public string Username { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Telefono { get; set; } = string.Empty;
    public DateTime FechaRegistro { get; set; } = DateTime.Now;
    public string EstadoMembresia { get; set; } = "Activa"; // Valor predeterminado
    public DateTime FechaFinMembresia { get; set; } = DateTime.MaxValue;
}
