using System;
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
        public DateTime CurrentArrival { get; set; }
        public DateTime CurrentDepartment { get; set; }
        public string CurrentCategory { get; set; }
        public int Quantity { get; set; }
        public string ReturnUrl { get; set; }
        public string LastName { get; set; }
    }
}
