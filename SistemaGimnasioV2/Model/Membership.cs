using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestiónGimnasioMVC.Model
{
    public class Membership
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Type { get; set; } // Tipo de membresía: Mensual, Semestral, Anual
        [Required]
        public DateTime StartDate { get; set; } // Fecha de inicio
        [Required]
        public DateTime EndDate { get; set; } // Fecha de fin
        [Required]
        public decimal Cost { get; set; } // Costo de la membresía
        [Required]
        public int ClientId { get; set; } // Relación con el cliente

        [ForeignKey("ClientId")]
        public User Client { get; set; } // Cliente asociado a la membresía
    }
}

