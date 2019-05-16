using Microsoft.EntityFrameworkCore;

namespace Hotel.Models
{
    public class ApplicationDbContext:DbContext
    {
        static bool FlagApplyMigrations = true;
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            if (FlagApplyMigrations)
            {
                FlagApplyMigrations = false;
                Database.Migrate();
                SeedData.EnsurePopulated(this);
            }
        }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<CheckIn> CheckIns { get; set; }
        public DbSet<Supply> Supplys { get; set; }
    }
}
