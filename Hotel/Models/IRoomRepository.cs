using System.Collections.Generic;

namespace Hotel.Models
{
    public interface IRoomRepository
    {
        IEnumerable<Room> Rooms { get; }
        void SaveRoom(Room room);
        void DeleteRoom(int roomID);
        void EditRoom(Room room);
       
        
    }
}
