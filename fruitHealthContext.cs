using FruitHealth.Models;
using Microsoft.EntityFrameworkCore;

namespace FruitHealth.Areas.Identity.Data
{
    public class fruitHealthContext : DbContext
    {
        public fruitHealthContext()
        {

        }

        public fruitHealthContext(DbContextOptions<fruitHealthContext> options) : base(options)
        {

        }

        public virtual DbSet<User> Users { get; set; }

        public virtual DbSet<FruitHealthPredictionResult> FruitHealthPredictionResults { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.;Database=FruitHealth;Integrated Security=True;TrustServerCertificate=True;MultipleActiveResultSets=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                
                entity.Property(e => e.FirstName)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasMaxLength(200);
            });
            modelBuilder.Entity<FruitHealthPredictionResult>(entity =>
            {
                entity.Property(e => e.Id)
            .          ValueGeneratedOnAdd();

                entity.Property(e => e.PredictedLabel)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Score)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ImageFilePath)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.PredictedDateTime)
                    .HasMaxLength(200);

            });
        }
    }
}
