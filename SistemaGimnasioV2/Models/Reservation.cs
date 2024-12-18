namespace SistemaGimnasioV2.Models
{
    public class Reservation
    {
        public int Id { get; set; }
        public DateTime ReservationDate { get; set; }

        // Relación con el cliente
        public int UserId { get; set; }
        public User? User { get; set; }

        // Relación con el horario de clase reservado
        public int ClassScheduleId { get; set; }
        public ClassSchedule? ClassSchedule { get; set; }
    }
}
