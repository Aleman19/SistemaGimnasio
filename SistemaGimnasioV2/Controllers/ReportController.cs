using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata;
using System.Text;
using Microsoft.EntityFrameworkCore;
using GestiónGimnasioMVC.Data;
using iTextSharp.text.pdf;
using iTextSharp.text;

namespace GestiónGimnasioMVC.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReportController : ControllerBase
    {
        private readonly GymDbContext _context;

        public ReportController(GymDbContext context) { _context = context; }
        // Reporte de Matrículas        [HttpGet("membership")]
        public async Task<IActionResult> GetMembershipReport()
        {
            var memberships = await _context.Memberships
                .Include(m => m.Client).ToListAsync();
            return Ok(memberships);
        }
        // Reporte Contable (Ingresos vs Egresos)        [HttpGet("financial")]
        public async Task<IActionResult> GetFinancialReport()
        {
            var totalIngresos = await _context.Memberships.SumAsync(m => m.Cost);
            var totalEgresos = await _context.InventoryItems.SumAsync(i => i.Cost);

            var report = new { Ingresos = totalIngresos, Egresos = totalEgresos, Balance = totalIngresos - totalEgresos };
            return Ok(report);
        }
        // Generar Reporte CSV de Clases        [HttpGet("classes/csv")]
        public async Task<IActionResult> ExportClassesReportToCSV()
        {
            var classes = await _context.Classes
                .Include(c => c.Trainer).ToListAsync();
            var csvBuilder = new StringBuilder();
            csvBuilder.AppendLine("Clase,Entrenador,Horario");

            foreach (var gymClass in classes)
            {
                csvBuilder.AppendLine($"{gymClass.Name},{gymClass.Trainer.Name},{gymClass.Schedule}");
            }

            var bytes = Encoding.UTF8.GetBytes(csvBuilder.ToString());
            return File(bytes, "text/csv", "Reporte_Clases.csv");
        }

        // Generar Reporte PDF de Clases
        [HttpGet("classes/pdf")]
        public async Task<IActionResult> ExportClassesReportToPDF()
        {
            var classes = await _context.Classes
                .Include(c => c.Trainer)
                .ToListAsync();

            using var stream = new MemoryStream();
            var document = new iTextSharp.text.Document();
            PdfWriter.GetInstance(document, stream);
            document.Open();

            document.Add(new Paragraph("Reporte de Clases"));
            document.Add(new Paragraph(" "));

            var table = new PdfPTable(3);
            table.AddCell("Clase");
            table.AddCell("Entrenador");
            table.AddCell("Horario");

            foreach (var gymClass in classes)
            {
                table.AddCell(gymClass.Name);
                table.AddCell(gymClass.Trainer.Name);
                table.AddCell(gymClass.Schedule.ToString());
            }

            document.Add(table);
            document.Close();

            var bytes = stream.ToArray();
            return File(bytes, "application/pdf", "Reporte_Clases.pdf");
        }
    }
}