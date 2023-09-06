using Domain.Entyties;
using Microsoft.EntityFrameworkCore;

namespace Service.DatabaseContext
{
    public class AppDbContext : DbContext
    {
        private readonly string connectionString = "Server=localhost;Port=5432;User Id=postgres;Password=56767655;Database=Companyy";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(connectionString);
            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<Company> companies { get; set; }
        public DbSet<Employee> employees { get; set; }
        public DbSet<Staff> staffs { get; set; }

    }
}
