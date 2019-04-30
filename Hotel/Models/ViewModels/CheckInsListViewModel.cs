using System.Collections.Generic;
using Hotel.Models;
using Hotel.Models.ViewModels;

namespace Hotel.Models.ViewModels
{
    public class CheckInsListViewModel
    {
        public IEnumerable<CheckIn> CheckIns { get; set; }
        public IEnumerable<Room> Rooms { get; set; }
        public IEnumerable<Customer> Customers { get; set; }
        public PagingInfo PagingInfo { get; set; }
        public int CustomerID { get; set; }
        public string CurArrival { get; set; }
        public string CurDepartment { get; set; }
    }
}
