namespace GestiónGimnasioMVC.Model
{
    public class Report
    {
        public string Title { get; set; } // Título del reporte
        public string Content { get; set; } // Contenido del reporte (formateado)
        public DateTime GeneratedAt { get; set; } = DateTime.Now; // Fecha de generación
    }
}
