using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestiónGimnasioMVC.Model
{
    public class Class
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; } // Nombre de la clase
        [MaxLength(200)]
        public string Description { get; set; } // Descripción de la clase
        [Required]
        public DateTime Schedule { get; set; } // Horario de la clase
        [Required]
        public int TrainerId { get; set; } // Relación con el entrenador

        [ForeignKey("TrainerId")]
        public User Trainer { get; set; } // Entrenador asignado
    }
}