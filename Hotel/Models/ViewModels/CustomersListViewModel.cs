using System;
using System.Collections.Generic;
using Hotel.Models;
using Hotel.Models.ViewModels;

namespace Hotel.Models.ViewModels
{
    public class CustomersListViewModel
    {
        public IEnumerable<Customer> Customers { get; set; }
        public IEnumerable<CheckIn> CheckIns { get; set; }
        public PagingInfo PagingInfo { get; set; }
        public string ReturnUrl{ get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime BithDate { get; set; }
        public int CheckInID { get; set; }
    }
}
