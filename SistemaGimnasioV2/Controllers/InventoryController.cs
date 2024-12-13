using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using GestiónGimnasioMVC.Data;
using GestiónGimnasioMVC.Model;

namespace GestiónGimnasioMVC.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InventoryController : ControllerBase
    {
        private readonly GymDbContext _context;

        public InventoryController(GymDbContext context) { _context = context; }
        [HttpGet]
        public async Task<IActionResult> GetAllInventoryItems()
        {
            var items = await _context.InventoryItems.ToListAsync();
            return Ok(items);
        }
        [HttpPost]
        public async Task<IActionResult> AddInventoryItem([FromBody] InventoryItem item)
        {
            if (item == null) return BadRequest(new { message = "Datos de inventario no válidos" });

            _context.InventoryItems.Add(item); await _context.SaveChangesAsync();
            return Ok(new { message = "Item agregado exitosamente", item });
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateInventoryItem(int id, [FromBody] InventoryItem updatedItem)
        {
            var item = await _context.InventoryItems.FindAsync(id);
            if (item == null) return NotFound(new { message = "Item no encontrado" });

            item.Name = updatedItem.Name;
            item.LifeSpan = updatedItem.LifeSpan;
            item.PurchaseDate = updatedItem.PurchaseDate;

            await _context.SaveChangesAsync();
            return Ok(new { message = "Item actualizado exitosamente" });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInventoryItem(int id)
        {
            var item = await _context.InventoryItems.FindAsync(id);
            if (item == null) return NotFound(new { message = "Item no encontrado" });

            _context.InventoryItems.Remove(item);
            await _context.SaveChangesAsync();
            return Ok(new { message = "Item eliminado exitosamente" });
        }
    }
}
