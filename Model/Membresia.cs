namespace Models
{
    public class Membresia
    {
        public int IdMembresia { get; set; }
        public int IdCliente { get; set; }
        public DateTime FechaInicio { get; set; } = DateTime.Now; // Valor predeterminado
        public DateTime FechaFin { get; set; } = DateTime.Now.AddMonths(1); // Ejemplo: Duración predeterminada de 1 mes
        public string Estado { get; set; } = "Activa"; // Estado inicial predeterminado
    }
}
