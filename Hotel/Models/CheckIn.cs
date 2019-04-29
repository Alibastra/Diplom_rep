using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel.Models
{
    public class CheckIn
    {
        public int CheckInID { get; set; }

        public DateTime Arrival { get; set; }

        public DateTime Department { get; set; }

        public int RoomID { get; set; }

        public int CustomerID { get; set; }
    }
}
