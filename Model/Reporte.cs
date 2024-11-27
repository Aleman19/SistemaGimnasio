using System;

namespace Model
{
    public class Reporte
    {
        public string Id { get; set; } = Guid.NewGuid().ToString(); // Generar un identificador único por defecto
        public string Titulo { get; set; } = string.Empty; // Evita valores nulos
        public string Descripcion { get; set; } = string.Empty; // Evita valores nulos
        public DateTime FechaGeneracion { get; set; } = DateTime.Now; // Fecha predeterminada
        public string Tipo { get; set; } = string.Empty; // Por ejemplo: "Clases", "Ingresos"
    }
}
