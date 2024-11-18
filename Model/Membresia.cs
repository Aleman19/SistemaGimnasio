using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

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

