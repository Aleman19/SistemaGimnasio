using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaGimnasioV2.Models
{
    public class Invoice
    {
        [Key]
        public int Id { get; set; } // Identificador único de la factura

        [Required(ErrorMessage = "El ID del usuario es obligatorio.")]
        public int UserId { get; set; } // Relación con el cliente que generó la factura

        [ForeignKey("UserId")]
        public User? User { get; set; } // Relación con el modelo User

        [Required(ErrorMessage = "La fecha de emisión es obligatoria.")]
        public DateTime Date { get; set; } = DateTime.Now; // Fecha de emisión de la factura con valor por defecto

        [Required(ErrorMessage = "El monto de la factura es obligatorio.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "El monto debe ser mayor a cero.")]
        public decimal Amount { get; set; } // Monto total de la factura

        [StringLength(500, ErrorMessage = "La descripción no puede exceder los 500 caracteres.")]
        public string Description { get; set; } = string.Empty; // Descripción de la factura (opcional)
    }
}
