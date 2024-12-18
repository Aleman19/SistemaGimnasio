using SistemaGimnasioV2.Models;

internal class GymUser : User
{
    // Redefinición de propiedades de la clase base
    public new string Username { get; set; } = string.Empty;
    public new string Password { get; set; } = string.Empty;
    public new string Role { get; set; } = string.Empty;
    public new string Email { get; set; } = string.Empty;
    public new string FirstName { get; set; } = string.Empty;
    public new string LastName { get; set; } = string.Empty;

   
}
