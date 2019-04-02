using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Hotel.Models
{
    public static class SeedData
    {
        public static void EnsurePopulated (IApplicationBuilder app)
        {
           // ApplicationDbContext context = app.ApplicationServices.GetRequiredService<ApplicationDbContext>();
            if (!context.Rooms.Any())
            {
                context.Rooms.AddRange(
                    new Room
                    {
                        RoomNumber = 1,
                        Price = 1200,
                        RoomID = 001,
                        Category = "Luxe",
                        HotelID = 200
                    },
                    new Room
                    {
                        RoomNumber = 2,
                        Price = 300,
                        RoomID = 002,
                        Category = "Econom",
                        HotelID = 200
                    },
                    new Room
                    {
                        RoomNumber = 3,
                        Price = 1200,
                        RoomID = 003,
                        Category = "Luxe",
                        HotelID = 200
                    },
                    new Room
                    {
                        RoomNumber = 4,
                        Price = 1200,
                        RoomID = 004,
                        Category = "Luxe",
                        HotelID = 200
                    },
                    new Room
                    {
                        RoomNumber = 5,
                        Price = 1200,
                        RoomID = 005,
                        Category = "Luxe",
                        HotelID = 200
                    }
                    );
                context.SaveChanges();
            }
        }
    }
}