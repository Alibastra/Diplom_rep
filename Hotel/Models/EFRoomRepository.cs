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
        public void SaveRoom (Room room)
        {
            context.AttachRange();
            context.Rooms.Add(room);
            context.SaveChanges();
        }

        public void DeleteRoom(int roomID)
        {
            Room room = Rooms.FirstOrDefault(r => r.RoomID == roomID);
            context.Rooms.Remove(room);
            context.SaveChanges();
        }
        public void EditRoom(Room room)
        {
            context.Rooms.Update(room);           
            context.SaveChanges();
        }
    }
}
