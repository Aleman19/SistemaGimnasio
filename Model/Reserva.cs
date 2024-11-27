namespace Models
{
    public class Reserva
    {
        public int IdReserva { get; set; }
        public int IdClase { get; set; }
        public int IdCliente { get; set; }
        public DateTime FechaReserva { get; set; } = DateTime.Now; // Valor predeterminado
        public string Estado { get; set; } = "Pendiente"; // Estado inicial predeterminado
    }
}
