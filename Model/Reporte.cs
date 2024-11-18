using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Model
{
    public class Reporte
    {
        public string Id { get; set; } // Identificador único del reportepublic string Titulo { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaGeneracion { get; set; }
        public string Tipo { get; set; } // Por ejemplo: "Clases", "Ingresos"
    }
}
