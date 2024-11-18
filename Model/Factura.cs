using System;

namespace Model
{
    public class Factura
    {
        public string Id { get; set; }
        public string ClienteId { get; set; }
        public DateTime FechaEmision { get; set; } // Asegúrate de que esta propiedad existe
        public decimal Total { get; set; }
        public string Detalles { get; set; }
    }
}
