using System.Collections.Generic;

namespace Hotel.Models
{
    public interface IRoomRepository
    {
        IEnumerable<Room> Rooms { get; }
        void InsertRoom(Room room);
        void DeleteRoom(Room room);
        void UpdateRoom(Room room);
    }
}
