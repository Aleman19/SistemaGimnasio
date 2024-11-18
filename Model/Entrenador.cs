using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Model
{ 
public class Entrenador
{
    public string Id { get; set; } // Identificador único del entrenadorpublic string Nombre { get; set; }
    public string Apellido { get; set; }
    public string Especialidades { get; set; } // Lista separada por comaspublic string Horarios { get; set; } // Texto descriptivo de horariospublic string Email { get; set; }
}
}
