using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Model
{
    public class Usuario
    {
        public string Id { get; set; } // Identificador único del usuariopublic string NombreUsuario { get; set; }
        public string Contraseña { get; set; }
        public string Rol { get; set; } // Por ejemplo: "Admin", "Cliente", "Entrenador"
    }
}
