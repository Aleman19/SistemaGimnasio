using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Model
{
    public class Factura
    {
        public string Id { get; set; } // Identificador único de la facturapublic string ClienteId { get; set; } // Relación con el clientepublic DateTime FechaEmision { get; set; }
        public decimal Total { get; set; }
        public string Detalles { get; set; } // Descripción de los cargos
    }
}