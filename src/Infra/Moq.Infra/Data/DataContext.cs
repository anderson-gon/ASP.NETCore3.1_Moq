using Microsoft.EntityFrameworkCore;
using Moq.Domain.Models;
using Moq.Infra.Mappings;

namespace Moq.Infra.Data
{
    public class DataContext : DbContext
    {

        public DbSet<User> User { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserMap());

            base.OnModelCreating(modelBuilder);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("");
        }
    }
}
