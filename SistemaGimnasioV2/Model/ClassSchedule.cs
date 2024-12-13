namespace SistemaGimnasioV2.Model
{
    public class ClassSchedule
    {
        public int Id { get; set; } // Identificador único para cada horario de clase
        public string ClassName { get; set; } // Nombre de la clase
        public DateTime StartTime { get; set; } // Hora de inicio
        public DateTime EndTime { get; set; } // Hora de fin
        public string TrainerName { get; set; } // Nombre del entrenador
    }
}

