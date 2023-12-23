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
            
        }
    }
}
