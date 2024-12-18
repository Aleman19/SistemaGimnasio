using Microsoft.EntityFrameworkCore;
using SistemaGimnasioV2.Models;

namespace SistemaGimnasioV2.Data
{
    public class GymDbContext : DbContext
    {
        public GymDbContext(DbContextOptions<GymDbContext> options) : base(options) { }

        // Definición de DbSet para las entidades
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<InventoryItem> InventoryItems { get; set; } = null!;
        public DbSet<Class> Classes { get; set; } = null!;
        public DbSet<ClassSchedule> ClassSchedules { get; set; } = null!;
        public DbSet<Reservation> Reservations { get; set; } = null!;
        public DbSet<ProgressMetric> Metrics { get; set; } = null!;
        public DbSet<Invoice> Invoices { get; set; } = null!;
        public DbSet<Membership> Memberships { get; set; } = null!;

        // Configuración de relaciones y modelo
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuración para ClassSchedule -> Class
            modelBuilder.Entity<ClassSchedule>()
                .HasOne(cs => cs.Class)                   // Relación con Class
                .WithMany()                               // Sin navegación inversa explícita
                .HasForeignKey(cs => cs.ClassId)          // Clave foránea
                .OnDelete(DeleteBehavior.Restrict);       // Evita eliminación en cascada

            // Configuración para ClassSchedule -> Trainer (User)
            modelBuilder.Entity<ClassSchedule>()
                .HasOne(cs => cs.Trainer)                 // Relación con Trainer
                .WithMany()                               // Sin navegación inversa explícita
                .HasForeignKey(cs => cs.TrainerId)        // Clave foránea
                .OnDelete(DeleteBehavior.Restrict);       // Evita eliminación en cascada

            // Configurar StartTime y EndTime como TimeSpan en la base de datos
            modelBuilder.Entity<ClassSchedule>()
                .Property(cs => cs.StartTime)
                .HasColumnType("time");

            modelBuilder.Entity<ClassSchedule>()
                .Property(cs => cs.EndTime)
                .HasColumnType("time");

            // Configuración para Reservation -> User
            modelBuilder.Entity<Reservation>()
                .HasOne(r => r.User)                      // Relación con User
                .WithMany(u => u.Reservations)            // Un usuario puede tener múltiples reservas
                .HasForeignKey(r => r.UserId)             // Clave foránea
                .OnDelete(DeleteBehavior.Restrict);       // Evita eliminación en cascada

            // Configuración para Reservation -> ClassSchedule
            modelBuilder.Entity<Reservation>()
                .HasOne(r => r.ClassSchedule)             // Relación con ClassSchedule
                .WithMany(cs => cs.Reservations)          // Un horario puede tener múltiples reservas
                .HasForeignKey(r => r.ClassScheduleId)    // Clave foránea
                .OnDelete(DeleteBehavior.Cascade);        // Eliminar reservas al eliminar el horario

            // Configuración de precisión para columnas decimales
            modelBuilder.Entity<InventoryItem>()
                .Property(i => i.Price)
                .HasPrecision(18, 2);

            modelBuilder.Entity<Invoice>()
                .Property(i => i.Amount)
                .HasPrecision(18, 2);

            modelBuilder.Entity<Membership>()
                .Property(m => m.Price)
                .HasPrecision(18, 2);
        }
    }
}
