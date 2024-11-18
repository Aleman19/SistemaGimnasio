
using System.Collections.Generic;
using Model;


namespace Controller
{
    public class ReporteController
    {
        public List<Reporte> GenerarReporteMatriculas(List<Membresia> membresias)
        {
            // Generar reporte de matrículas (e.g., por mes o año)
            return new List<Reporte>();
        }

        public List<Reporte> GenerarReporteIngresos(List<Factura> facturas)
        {
            // Generar reporte contable (ingresos vs egresos)
            return new List<Reporte>();
        }

        public List<Reporte> GenerarReporteClases(List<Clase> clases, List<Reserva> reservas)
        {
            // Generar reporte de clases más populares
            return new List<Reporte>();
        }
    }
}

