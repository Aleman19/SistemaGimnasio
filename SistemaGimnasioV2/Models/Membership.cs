using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SistemaGimnasioV2.Models
{
    public class Membership
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "El nombre del plan no debe superar los 50 caracteres.")]
        public string PlanName { get; set; } = string.Empty;

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "El precio debe ser positivo.")]
        public decimal Price { get; set; }

        public bool IsPaid { get; set; } = false; // Estado del pago

        // Relación con el cliente
        [Required]
        public int UserId { get; set; }
        public User? User { get; set; }

        // Propiedad Calculada: Días restantes para el vencimiento
        [NotMapped]
        public int DaysToExpire => (EndDate - DateTime.Now).Days;

        // Nuevo: Método para renovar membresía
        public void RenewMembership(int durationInMonths, decimal price)
        {
            StartDate = DateTime.Now;
            EndDate = DateTime.Now.AddMonths(durationInMonths);
            Price = price;
            IsPaid = true; // Se asume que al renovar, se marca como pagada
        }
    }
}
