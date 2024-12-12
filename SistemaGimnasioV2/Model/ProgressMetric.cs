using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestiónGimnasioMVC.Model
{
    public class ProgressMetric
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int ClientId { get; set; } // Relación con el cliente

        [ForeignKey("ClientId")]
        public User Client { get; set; } // Cliente asociado

        [Required]
        [MaxLength(50)]
        public string MetricType { get; set; } // Tipo de métrica: Pecho, Bíceps, Peso, etc.

        [Required]
        public decimal Value { get; set; } // Valor de la métrica

        [Required]
        public DateTime Date { get; set; } // Fecha de registro de la métrica
    }
}
