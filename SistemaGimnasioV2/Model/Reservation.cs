using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace GestiónGimnasioMVC.Model
{
    public class Reservation
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int ClassId { get; set; } // Relación con la clase
        [ForeignKey("ClassId")]
        public Class GymClass { get; set; } // Clase asociada
        [Required]
        public int ClientId { get; set; } // Relación con el cliente
        [ForeignKey("ClientId")]
        public User Client { get; set; } // Cliente asociado

        [Required]
        public DateTime ReservationDate { get; set; } = DateTime.Now; // Fecha de la reserva
    }
}