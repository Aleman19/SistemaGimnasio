using Microsoft.EntityFrameworkCore;

public class GymDbContext : DbContext
{
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().HasData(
            new User { Id = 1, Cedula = "12345678", Password = "admin123", Role = "Administrador" },
            new User { Id = 2, Cedula = "87654321", Password = "trainer123", Role = "Entrenador" },
            new User { Id = 3, Cedula = "45678912", Password = "client123", Role = "Cliente" }
        );
    }
}
