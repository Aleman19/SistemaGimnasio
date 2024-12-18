using SistemaGimnasioV2.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

public class User
{
    public int Id { get; set; }

    [Required(ErrorMessage = "El nombre de usuario es obligatorio.")]
    [MaxLength(50, ErrorMessage = "El nombre de usuario no debe exceder los 50 caracteres.")]
    public string Username { get; set; } = string.Empty;

    [Required(ErrorMessage = "El correo electrónico es obligatorio.")]
    [EmailAddress(ErrorMessage = "El formato del correo electrónico no es válido.")]
    public string Email { get; set; } = string.Empty;

    [Required(ErrorMessage = "El rol es obligatorio.")]
    public string Role { get; set; } = string.Empty;

    [Required(ErrorMessage = "La contraseña es obligatoria.")]
    [MinLength(8, ErrorMessage = "La contraseña debe tener al menos 8 caracteres.")]
    public string Password { get; set; } = string.Empty;

    [Required(ErrorMessage = "El primer nombre es obligatorio.")]
    public string FirstName { get; set; } = string.Empty;

    [Required(ErrorMessage = "El apellido es obligatorio.")]
    public string LastName { get; set; } = string.Empty;

    // FullName es solo de lectura, se deriva de FirstName y LastName
    public string FullName => $"{FirstName} {LastName}";

    // Nueva propiedad opcional: Teléfono
    [Phone(ErrorMessage = "El formato del número de teléfono no es válido.")]
    public string? PhoneNumber { get; set; }

    // Nueva propiedad opcional: Fecha de Registro
    public DateTime? RegisteredDate { get; set; }

    // Relación con el entrenador asignado
    public int? TrainerId { get; set; }
    [ForeignKey("TrainerId")]
    public User? AssignedTrainer { get; set; }

    // Nueva relación: Clientes asignados al entrenador
    public ICollection<User> Clients { get; set; } = new List<User>();

    // Relaciones adicionales
    public ICollection<Membership> Memberships { get; set; } = new List<Membership>();
    public ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
    public ICollection<ClassSchedule> AssignedClasses { get; set; } = new List<ClassSchedule>();
}
