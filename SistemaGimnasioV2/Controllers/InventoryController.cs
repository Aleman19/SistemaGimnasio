using Microsoft.AspNetCore.Mvc;
using SistemaGimnasioV2.Data;
using SistemaGimnasioV2.Models;
using System.Linq;

namespace SistemaGimnasioV2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InventoryController : ControllerBase
    {
        private readonly GymDbContext _dbContext;

        public InventoryController(GymDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // GET: api/Inventory
        [HttpGet]
        public IActionResult GetInventory()
        {
            var items = _dbContext.InventoryItems.ToList();
            return Ok(items);
        }

        // GET: api/Inventory/Expiring
        [HttpGet("Expiring")]
        public IActionResult GetExpiringItems()
        {
            var currentDate = DateTime.Now;

            // Filtrar ítems a 3 meses o menos de su vencimiento y aún no notificados
            var expiringItems = _dbContext.InventoryItems
                .Where(i => !i.IsNotified &&
                            i.PurchaseDate.AddMonths(i.LifeSpanMonths - 3) <= currentDate)
                .ToList();

            return Ok(expiringItems);
        }

        // POST: api/Inventory/Add
        [HttpPost("Add")]
        public IActionResult AddItem([FromBody] InventoryItem item)
        {
            if (item == null)
                return BadRequest("Datos del inventario no válidos.");

            // Validar datos
            if (item.PurchaseDate == DateTime.MinValue || item.LifeSpanMonths <= 0)
                return BadRequest("Fecha de compra o vida útil no válidas.");

            _dbContext.InventoryItems.Add(item);
            _dbContext.SaveChanges();

            return Ok(item);
        }

        // PUT: api/Inventory/MarkNotified
        [HttpPut("MarkNotified")]
        public IActionResult MarkItemsAsNotified([FromBody] List<int> itemIds)
        {
            var items = _dbContext.InventoryItems
                .Where(i => itemIds.Contains(i.Id))
                .ToList();

            if (!items.Any())
                return NotFound("No se encontraron ítems para actualizar.");

            foreach (var item in items)
            {
                item.IsNotified = true;
            }

            _dbContext.SaveChanges();

            return Ok("Los ítems fueron marcados como notificados.");
        }

        // DELETE: api/Inventory/Delete/5
        [HttpDelete("Delete/{id}")]
        public IActionResult DeleteItem(int id)
        {
            var item = _dbContext.InventoryItems.FirstOrDefault(i => i.Id == id);
            if (item == null)
                return NotFound("Ítem de inventario no encontrado.");

            _dbContext.InventoryItems.Remove(item);
            _dbContext.SaveChanges();

            return Ok($"Ítem con ID {id} eliminado.");
        }
    }
}
