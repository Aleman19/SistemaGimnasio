using System;

namespace Model
{
    public class Reserva
    {
        public string Id { get; set; }
        public string ClienteId { get; set; }
        public string ClaseId { get; set; } // Asegúrate de que esta propiedad existe
        public DateTime FechaReserva { get; set; } // Asegúrate de que esta propiedad existe
    }
}
