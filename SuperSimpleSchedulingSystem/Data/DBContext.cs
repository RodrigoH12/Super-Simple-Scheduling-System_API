using Microsoft.EntityFrameworkCore;
using SuperSimpleSchedulingSystem.Configuration;
using SuperSimpleSchedulingSystem.Data.Models;

namespace SuperSimpleSchedulingSystem.Data
{
    public class DBContext : DbContext
    {
        public DBContext(IApplicationConfiguration applicationConfiguration)
        {
            _applicationConfiguration = applicationConfiguration;
        }

        private readonly IApplicationConfiguration _applicationConfiguration;
        public DbSet<User> User { get; set; }
        public DbSet<Student> Student { get; set; }
        public DbSet<Class> Class { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_applicationConfiguration.GetDatabaseConnectionString().DATABASE);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("dbo");

            modelBuilder.Entity<Class>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("PK_Class_Id");

                entity.HasMany(e => e.Students)
                    .WithMany(e => e.Classes);
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("PK_Student_Id");

                entity.HasOne(e => e.User)
                    .WithOne(e => e.Student)
                    .HasForeignKey<Student>(e => e.UserId)
                    .HasConstraintName("FK_Student_UserId")
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("PK_User_Id");
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
