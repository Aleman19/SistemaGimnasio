using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestiónGimnasioMVC.Model
{
    public class Invoice
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int ClientId { get; set; } // Relación con el cliente

        [ForeignKey("ClientId")]
        public User Client { get; set; } // Cliente asociado

        [Required]
        public DateTime Date { get; set; } = DateTime.Now; // Fecha de emisión

        [Required]
        public decimal Total { get; set; } // Total de la factura

        [MaxLength(500)]
        public string Details { get; set; } // Descripción detallada
    }
}
