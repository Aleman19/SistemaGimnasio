using Microsoft.AspNetCore.Mvc;
using SistemaGimnasioV2.Data;
using SistemaGimnasioV2.Models;

[ApiController]
[Route("api/[controller]")]
public class InvoiceController : ControllerBase
{
    private readonly GymDbContext _dbContext;

    public InvoiceController(GymDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    // GET: api/Invoice/Client/5
    [HttpGet("Client/{clientId}")]
    public IActionResult GetInvoicesByClient(int clientId)
    {
        var invoices = _dbContext.Invoices.Where(i => i.UserId == clientId).ToList();
        if (!invoices.Any())
            return NotFound("No se encontraron facturas para este cliente.");

        return Ok(invoices);
    }

    // POST: api/Invoice/Add
    [HttpPost("Add")]
    public IActionResult AddInvoice([FromBody] Invoice newInvoice)
    {
        if (newInvoice == null)
            return BadRequest("Datos de la factura no válidos.");

        _dbContext.Invoices.Add(newInvoice);
        _dbContext.SaveChanges();

        return Ok(newInvoice);
    }

    // DELETE: api/Invoice/Delete/5
    [HttpDelete("Delete/{invoiceId}")]
    public IActionResult DeleteInvoice(int invoiceId)
    {
        var invoice = _dbContext.Invoices.FirstOrDefault(i => i.Id == invoiceId);
        if (invoice == null)
            return NotFound("Factura no encontrada.");

        _dbContext.Invoices.Remove(invoice);
        _dbContext.SaveChanges();

        return Ok($"Factura con ID {invoiceId} eliminada.");
    }
}
