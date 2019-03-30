using System.Collections.Generic;

namespace Hotel.Models
{
    public class FakeRoomRepository : IRoomRepository
    {
        public IEnumerable<Room> Rooms => new List<Room> {
            new Room { RoomNumber = 1, Price = 1200 },
            new Room { RoomNumber = 2, Price = 700 },
            new Room { RoomNumber = 5, Price = 1300 }
        };
    }
}
