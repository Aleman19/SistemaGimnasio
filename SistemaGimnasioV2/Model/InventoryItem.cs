using System.ComponentModel.DataAnnotations;

namespace GestiónGimnasioMVC.Model
{
    public class InventoryItem
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; } // Nombre del equipo/máquina

        [Required]
        public DateTime PurchaseDate { get; set; } // Fecha de compra

        [Required]
        public int LifeSpan { get; set; } // Vida útil en meses

        [Required]
        public decimal Cost { get; set; } // Costo del equipo
    }
}
