using System.Collections.Generic;
using Hotel.Models;
using Hotel.Models.ViewModels;

namespace Hotel.Models.ViewModels
{
    public class SupplysListViewModel
    {
        public IEnumerable<Supply> Supplys { get; set; }
        public IEnumerable<Service> Services { get; set; }
        public int CheckInID { get; set; }
        public string ReturnUrl { get; set; }
        public int SupplyID { get; set; }
        public PagingInfo PagingInfo { get; set; }
        public string Category { get; set; }
        public int ServiceID { get; set; }
    }
}
