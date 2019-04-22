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
            context.AttachRange(room.RoomID);
            if (room.RoomID == 0)
            {
                context.Rooms.Add(room);
            }
            context.SaveChanges();
        }
    }
}
