using System.Collections.Generic;
using Hotel.Models;
using Hotel.Models.ViewModels;

namespace Hotel.Models.ViewModels
{
    public class SupplyViewModel
    {
        public Supply Supply { get; set; }
        public Service Service { get; set; }
        public string ReturnUrl { get; set; }
    }
}
