﻿namespace Model
{
    public class Clase
    {
        public string Id { get; set; } // Identificador único de la clasepublic string Nombre { get; set; }
        public string EntrenadorId { get; set; } // Relación con el entrenadorpublic string Horario { get; set; }
        public int CupoMaximo { get; set; }
        public string Descripcion { get; set; }
    }
}