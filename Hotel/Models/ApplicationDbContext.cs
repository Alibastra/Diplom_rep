using Microsoft.EntityFrameworkCore;

namespace Hotel.Models
{
    public class ApplicationDbContext:DbContext
    {
        bool FlagConfigureContextForMigration = false;
        static bool FlagApplyMigrations = true;
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            if (FlagApplyMigrations)
            {
                FlagApplyMigrations = false;
                Database.Migrate();
            }
        }
        public DbSet<Room> Rooms { get; set; }
    }
}
