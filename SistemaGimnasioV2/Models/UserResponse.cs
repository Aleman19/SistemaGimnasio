namespace SistemaGimnasioV2.Models
{
    public class UserResponse
    {
        public required string Message { get; set; }
        public required UserResponseDetails User { get; set; } // Renombrado
    }

    public class UserResponseDetails // Renombrado
    {
        public int Id { get; set; }
        public required string Username { get; set; }
        public required string Role { get; set; }
    }
}
