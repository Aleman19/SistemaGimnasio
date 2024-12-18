using System.ComponentModel.DataAnnotations;

namespace SistemaGimnasioV2.Models
{
    public class Class
    {
        [Key] // Define la clave primaria
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre de la clase es obligatorio.")]
        [StringLength(100, ErrorMessage = "El nombre no puede tener más de 100 caracteres.")]
        public string Name { get; set; } = string.Empty; // Nombre de la clase

        [Required(ErrorMessage = "La descripción de la clase es obligatoria.")]
        [StringLength(500, ErrorMessage = "La descripción no puede tener más de 500 caracteres.")]
        public string Description { get; set; } = string.Empty; // Descripción detallada de la clase

        [Required(ErrorMessage = "La fecha de inicio es obligatoria.")]
        public DateTime StartDate { get; set; } // Fecha y hora de inicio de la clase

        [Required(ErrorMessage = "La duración es obligatoria.")]
        [Range(10, 180, ErrorMessage = "La duración debe estar entre 10 y 180 minutos.")]
        public int DurationMinutes { get; set; } // Duración de la clase en minutos

        [Required(ErrorMessage = "El estado de la clase es obligatorio.")]
        public bool IsActive { get; set; } = true; // Estado de la clase (activa/inactiva)

        // Relación con los horarios asociados a esta clase
        public ICollection<ClassSchedule>? Schedules { get; set; }

        // Propiedad calculada para obtener el horario de finalización
        public DateTime EndDate => StartDate.AddMinutes(DurationMinutes);

        public ICollection<ClassSchedule> ClassSchedules { get; set; } = new List<ClassSchedule>();
    }
}
