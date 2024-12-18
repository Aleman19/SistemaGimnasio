using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaGimnasioV2.Models
{
    public class ClassSchedule
    {
        public int Id { get; set; } // Identificador único del horario

        [Required(ErrorMessage = "La fecha es obligatoria.")]
        public DateTime Date { get; set; } // Fecha de la clase programada

        [Required(ErrorMessage = "La hora de inicio es obligatoria.")]
        public TimeSpan StartTime { get; set; } // Hora de inicio

        [Required(ErrorMessage = "La hora de finalización es obligatoria.")]
        [CustomValidation(typeof(ClassSchedule), nameof(ValidateEndTime))]
        public TimeSpan EndTime { get; set; } // Hora de finalización

        // Relación con la clase
        [Required(ErrorMessage = "La clase es obligatoria.")]
        public int ClassId { get; set; } // Clave foránea para Class
        public Class Class { get; set; } // Relación con Class

        // Relación con el entrenador
        [Required(ErrorMessage = "El entrenador es obligatorio.")]
        public int TrainerId { get; set; } // Clave foránea para Trainer (User)
        public User? Trainer { get; set; } // Relación con User (Trainer)

        // Relación con reservas
        public ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();

        // Propiedades calculadas
        [NotMapped]
        public string TrainerName => Trainer?.FullName ?? "Sin asignar";

        [NotMapped]
        public string ClassName => Class?.Name ?? "Clase no asignada";

        // Método de validación para EndTime
        public static ValidationResult? ValidateEndTime(TimeSpan endTime, ValidationContext context)
        {
            var instance = context.ObjectInstance as ClassSchedule;
            if (instance != null && endTime <= instance.StartTime)
            {
                return new ValidationResult("La hora de finalización debe ser mayor que la hora de inicio.");
            }
            return ValidationResult.Success;
        }
    }
}
