﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
namespace Model
{
    public class Cliente
{
    public string Id { get; set; } // Identificador único del clientepublic string Nombre { get; set; }
    public string Apellido { get; set; }
    public string Email { get; set; }
    public string Telefono { get; set; }
    public string MembresiaId { get; set; } // Relación con la membresíapublic DateTime FechaRegistro { get; set; }
}
}
