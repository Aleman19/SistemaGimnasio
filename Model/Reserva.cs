using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Model
{
    public class Reserva
    {
        public string Id { get; set; } // Identificador único de la reservapublic string ClienteId { get; set; } // Relación con el clientepublic string ClaseId { get; set; } // Relación con la clasepublic DateTime FechaReserva { get; set; }
    }
}
