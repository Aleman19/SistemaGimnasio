using System;


namespace Model
{
    public class Membresia
    {
        public string Id { get; set; } // Identificador único de la membresíapublic string ClienteId { get; set; } // Relación con el clientepublic DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public decimal Costo { get; set; }
        public string Tipo { get; set; } // Por ejemplo: "Mensual", "Anual"
    }
}

