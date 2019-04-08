using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Hotel.Models
{
    public static class SeedData
    {
        public static void EnsurePopulated (IApplicationBuilder app)
        {
            ApplicationDbContext context = app.ApplicationServices.GetRequiredService<ApplicationDbContext>();
            if (!context.Rooms.Any())
            {
                context.Rooms.AddRange(
                    new Room
                    {
                        RoomID = 1,
                        Price = 1200,
                        Category = "Luxe",
                        Quantity = 2
                    },
                    new Room
                    {
                        RoomID = 2,
                        Price = 300,
                        Category = "Econom",
                        Quantity = 2
                    },
                    new Room
                    {
                        RoomID = 3,
                        Price = 1200,
                        Category = "Luxe",
                        Quantity = 2
                    },
                    new Room
                    {
                        RoomID = 4,
                        Price = 1200,
                        Category = "Luxe",
                        Quantity = 2
                    },
                    new Room
                    {
                        RoomID = 5,
                        Price = 1200,
                        Category = "Luxe",
                        Quantity = 3
                    }
                    );
                context.SaveChanges();
            }
        }
    }
}