using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel.Models
{
    public class Room
    {
        public int RoomID { get; set; }
        public int  RoomNumber { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }
        public int HotelID { get; set; }
    }
}
