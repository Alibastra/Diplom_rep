using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel.Models.ViewModels
{
    public class NavigationMenuRoomViewModel
    {
        public string CurrentCategory { get; set; }
        public IEnumerable<string> Categorys { get; set; }
    }
}
