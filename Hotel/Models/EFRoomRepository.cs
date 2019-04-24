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
            //if (room.RoomID == )
            //{
            context.Rooms.Add(room);
            //}
            context.SaveChanges();
        }

        public void DeleteRoom(int roomID)
        {
            //if (room.RoomID != null)
            //{
                Room room = Rooms.FirstOrDefault(r => r.RoomID == roomID);
                context.Rooms.Remove(room);
                context.SaveChanges();
             //}
        }


    }
}
