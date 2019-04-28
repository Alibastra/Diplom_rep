using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Hotel.Models
{
    public class EFRoomRepository: IRoomRepository
    {
        private ApplicationDbContext context;
        public EFRoomRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }
        public IEnumerable<Room> Rooms => context.Rooms;

        public void InsertRoom (Room room)
        {
            context.AttachRange();
            context.Rooms.Add(room);
            context.SaveChanges();
        }

        public void DeleteRoom(Room room)
        {
            context.Rooms.Remove(room);
            context.SaveChanges();
        }
        public void UpdateRoom(Room room)
        {
            context.Rooms.Update(room);
            context.SaveChanges();
        }
    }
}
