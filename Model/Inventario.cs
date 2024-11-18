using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Model
{
    public class Inventario
    {
        public string Id { get; set; } // Identificador único del artículopublic string Nombre { get; set; } // Nombre del equipo o artículopublic string Categoria { get; set; } // Por ejemplo: "Máquina", "Pesas"public DateTime FechaAdquisicion { get; set; }
        public int VidaUtilMeses { get; set; }
        public bool EnUso { get; set; } // Indica si el equipo está activo
    }
}
