using System.Collections.Generic;
using Hotel.Models;
using Hotel.Models.ViewModels;

namespace Hotel.Models.ViewModels
{
    public class CheckInViewModel
    {
        public CheckIn CheckIn { get; set; }
        public Room Room { get; set; }
        public string ReturnUrl { get; set; }
    }
}
