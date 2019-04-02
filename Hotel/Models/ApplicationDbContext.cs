using Microsoft.EntityFrameworkCore;

namespace Hotel.Models
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<Room> Rooms { get; set; }
    }
}
