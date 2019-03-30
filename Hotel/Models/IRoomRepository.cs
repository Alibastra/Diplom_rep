using System.Collections.Generic;

namespace Hotel.Models
{
    public interface IRoomRepository
    {
        IEnumerable<Room> Rooms { get; }
    }
}
