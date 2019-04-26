using System.Collections.Generic;
using Hotel.Models;
using Hotel.Models.ViewModels;

namespace Hotel.Models.ViewModels
{
    public class EditRoomViewModel
    {
        public IEnumerable<Room> Rooms { get; set; }
        public string ReturnUrl { get; set; }
    }
}
