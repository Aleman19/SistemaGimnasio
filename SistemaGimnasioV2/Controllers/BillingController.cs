using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using SistemaGimnasioV2.Model;

namespace GestiónGimnasioMVC.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BillingController : ControllerBase
    {
        private readonly GymDbContext _context;

        public BillingController(GymDbContext context) { _context = context; }
        // Obtener todas las facturas        [HttpGet]
        public async Task<IActionResult> GetAllInvoices()
        {
            var invoices = await _context.Invoices
                .Include(i => i.Client).ToListAsync();
            return Ok(invoices);
        }
        // Obtener una factura por ID        [HttpGet("{id}")]
        public async Task<IActionResult> GetInvoiceById(int id)
        {
            var invoice = await _context.Invoices.Include(i => i.Client).FirstOrDefaultAsync(i => i.Id == id);
            if (invoice == null) return NotFound(new { message = "Factura no encontrada" });

            return Ok(invoice);
        }
        // Generar una nueva factura        [HttpPost]
        public async Task<IActionResult> CreateInvoice([FromBody] Invoice invoice)
        {
            if (invoice == null) return BadRequest(new { message = "Datos de la factura no válidos" });

            invoice.Date = DateTime.Now; // Fecha de generación            _context.Invoices.Add(invoice);            await _context.SaveChangesAsync();

            return Ok(new { message = "Factura generada exitosamente", invoice });
        }
        // Actualizar factura existente        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateInvoice(int id, [FromBody] Invoice updatedInvoice)
        {
            var invoice = await _context.Invoices.FindAsync(id);
            if (invoice == null) return NotFound(new { message = "Factura no encontrada" });

            invoice.Total = updatedInvoice.Total;
            invoice.Details = updatedInvoice.Details;

            await _context.SaveChangesAsync();
            return Ok(new { message = "Factura actualizada exitosamente" });
        }

        // Eliminar factura
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInvoice(int id)
        {
            var invoice = await _context.Invoices.FindAsync(id);
            if (invoice == null) return NotFound(new { message = "Factura no encontrada" });

            _context.Invoices.Remove(invoice);
            await _context.SaveChangesAsync();
            return Ok(new { message = "Factura eliminada exitosamente" });
        }
    }
}
