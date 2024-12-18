using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaGimnasioV2.Data;
using SistemaGimnasioV2.Models;

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
        public async Task<ActionResult<IEnumerable<InventoryItem>>> GetInventory()
        {
            try
            {
                var items = await _dbContext.InventoryItems.ToListAsync();
                return Ok(items);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        // GET: api/Inventory/Expiring
        [HttpGet("Expiring")]
        public async Task<ActionResult<IEnumerable<InventoryItem>>> GetExpiringItems()
        {
            try
            {
                var currentDate = DateTime.Now;

                var expiringItems = await _dbContext.InventoryItems
                    .Where(i => !i.IsNotified &&
                                i.PurchaseDate.AddMonths(i.LifeSpanMonths - 3) <= currentDate)
                    .ToListAsync();

                return Ok(expiringItems);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        // POST: api/Inventory/Add
        [HttpPost("Add")]
        public async Task<ActionResult<InventoryItem>> AddItem([FromBody] InventoryItem item)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (item.PurchaseDate == DateTime.MinValue || item.LifeSpanMonths <= 0)
                return BadRequest("Fecha de compra o vida útil no válidas.");

            try
            {
                _dbContext.InventoryItems.Add(item);
                await _dbContext.SaveChangesAsync();

                return CreatedAtAction(nameof(GetInventory), new { id = item.Id }, item);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al agregar el ítem: {ex.Message}");
            }
        }

        // PUT: api/Inventory/MarkNotified
        [HttpPut("MarkNotified")]
        public async Task<ActionResult> MarkItemsAsNotified([FromBody] List<int> itemIds)
        {
            if (itemIds == null || !itemIds.Any())
                return BadRequest("No se proporcionaron IDs válidos.");

            try
            {
                var items = await _dbContext.InventoryItems
                    .Where(i => itemIds.Contains(i.Id))
                    .ToListAsync();

                if (!items.Any())
                    return NotFound("No se encontraron ítems para actualizar.");

                foreach (var item in items)
                {
                    item.IsNotified = true;
                }

                await _dbContext.SaveChangesAsync();

                return Ok("Los ítems fueron marcados como notificados.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al actualizar los ítems: {ex.Message}");
            }
        }

        // DELETE: api/Inventory/Delete/{id}
        [HttpDelete("Delete/{id}")]
        public async Task<ActionResult> DeleteItem(int id)
        {
            try
            {
                var item = await _dbContext.InventoryItems.FindAsync(id);
                if (item == null)
                    return NotFound("Ítem de inventario no encontrado.");

                _dbContext.InventoryItems.Remove(item);
                await _dbContext.SaveChangesAsync();

                return Ok($"Ítem con ID {id} eliminado.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al eliminar el ítem: {ex.Message}");
            }
        }
    }
}
