using System.Collections.Generic;
using Hotel.Models;
using Hotel.Models.ViewModels;

namespace Hotel.Models.ViewModels
{
    public class SupplysListViewModel
    {
        public IEnumerable<Supply> Supplys { get; set; }
        public PagingInfo PagingInfo { get; set; }
        public string CurrentCategory { get; set; }
        public string ReturnUrl { get; set; }
        public int CheckInID { get; set; }
    }
}
