using Microsoft.EntityFrameworkCore;
using GestiónGimnasioMVC.Model;
using SistemaGimnasioV2.Model;

namespace GestiónGimnasioMVC.Data
{
    public class GymDbContext : DbContext
    {
        public GymDbContext(DbContextOptions<GymDbContext> options) : base(options) { }

        public required DbSet<User> Users { get; set; }
        public required DbSet<Membership> Memberships { get; set; }
        public required DbSet<Class> Classes { get; set; }
        public required DbSet<Reservation> Reservations { get; set; }
        public required DbSet<InventoryItem> InventoryItems { get; set; }
        public required DbSet<Invoice> Invoices { get; set; }
        public required DbSet<ProgressMetric> ProgressMetrics { get; set; }
        public required DbSet<ClassSchedule> ClassSchedules { get; set; }


        // Configuración personalizada de las tablas
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuración inicial para usuarios (Seed Data)
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    Cedula = "12345678",
                    Password = "admin123", // Nota: Siempre usar encriptación en producción
                    Role = "Administrador",
                    Name = "Admin Principal",
                    Email = "admin@gym.com"
                },
                new User
                {
                    Id = 2,
                    Cedula = "87654321",
                    Password = "trainer123",
                    Role = "Entrenador",
                    Name = "Entrenador Juan",
                    Email = "juan@gym.com"
                },
                new User
                {
                    Id = 3,
                    Cedula = "45678912",
                    Password = "client123",
                    Role = "Cliente",
                    Name = "Cliente Ana",
                    Email = "ana@gym.com"
                }
            );

            // Configuración de relaciones
            modelBuilder.Entity<Membership>()
                .HasOne(m => m.Client)
                .WithMany()
                .HasForeignKey(m => m.ClientId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Class>()
                .HasOne(c => c.Trainer)
                .WithMany()
                .HasForeignKey(c => c.TrainerId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Reservation>()
                .HasOne(r => r.GymClass)
                .WithMany()
                .HasForeignKey(r => r.ClassId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Reservation>()
                .HasOne(r => r.Client)
                .WithMany()
                .HasForeignKey(r => r.ClientId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Invoice>()
                .HasOne(i => i.Client)
                .WithMany()
                .HasForeignKey(i => i.ClientId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ProgressMetric>()
                .HasOne(pm => pm.Client)
                .WithMany()
                .HasForeignKey(pm => pm.ClientId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
