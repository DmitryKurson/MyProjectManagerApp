using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyProjectManagerApp.Models;
using Task = MyProjectManagerApp.Models.Task;

namespace MyProjectManagerApp.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }
        public DbSet<Project> projects { get; set; } = null!;
        public DbSet<Task> tasks { get; set; } = null!;
        public DbSet<Worker> workers { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Project>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);
                entity.Property(e => e.Description)
                    .HasMaxLength(500);
                entity.Property(e => e.CreatorName)
                    .HasMaxLength(100);
            });

            // Task configuration
            modelBuilder.Entity<Task>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);
                entity.Property(e => e.Description)
                    .HasMaxLength(500);
                entity.Property(e => e.WorkerName)
                    .HasMaxLength(100);
                entity.Property(e => e.Time)
                    .IsRequired();
            });

            // Worker configuration
            modelBuilder.Entity<Worker>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);
                entity.Property(e => e.Surname)
                    .IsRequired()
                    .HasMaxLength(100);
                entity.Property(e => e.Position)
                    .HasMaxLength(100);
                entity.Property(e => e.Salary)
                    .IsRequired();
            });
            base.OnModelCreating(modelBuilder);
        }
    }
}
