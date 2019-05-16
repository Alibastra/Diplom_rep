using System.Collections.Generic;
using Hotel.Models;
using Hotel.Models.ViewModels;

namespace Hotel.Models.ViewModels
{
    public class CheckInNewViewModel
    {
        public CheckIn CheckIn { get; set; }
        public string Category { get; set; }
        public int Quantity { get; set; }
        public IEnumerable<Room> Rooms { get; set; }
        public PagingInfo PagingInfo { get; set; }
        public string ReturnUrl { get; set; }
    }
}
