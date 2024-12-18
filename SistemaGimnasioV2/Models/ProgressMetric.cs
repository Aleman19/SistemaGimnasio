


namespace SistemaGimnasioV2.Models
{
    public class ProgressMetric
    {
        public int Id { get; set; } // Identificador único de la métrica
        public int UserId { get; set; } // Relación con el usuario
        public User? User { get; set; } // Relación con el modelo User
        public float Weight { get; set; } // Peso del cliente en kg
        public float Height { get; set; } // Altura del cliente en cm
        public float BMI { get; set; } // Índice de masa corporal calculado
        public DateTime Date { get; set; } // Fecha en la que se registró la métrica
        public DateTime LastUpdated { get; set; } // Última actualización de las métricas
    }
}
