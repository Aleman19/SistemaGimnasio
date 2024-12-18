using System.ComponentModel.DataAnnotations;

namespace SistemaGimnasioV2.Models
{
    public class InventoryItem
    {
        public int Id { get; set; } // Identificador único del ítem

        [Required(ErrorMessage = "El nombre del ítem es obligatorio.")]
        public string Name { get; set; } = string.Empty; // Nombre del ítem

        public int Quantity { get; set; } // Cantidad disponible en inventario

        [Range(0.01, double.MaxValue, ErrorMessage = "El precio debe ser mayor que 0.")]
        public decimal Price { get; set; } // Precio del ítem

        [Required(ErrorMessage = "La fecha de compra es obligatoria.")]
        public DateTime PurchaseDate { get; set; } // Fecha de compra del equipo

        [Required(ErrorMessage = "La vida útil es obligatoria.")]
        [Range(1, 120, ErrorMessage = "La vida útil debe estar entre 1 y 120 meses.")]
        public int LifeSpanMonths { get; set; } // Vida útil en meses

        public bool IsNotified { get; set; } = false; // Estado de notificación (true si ya se notificó)
    }
}
