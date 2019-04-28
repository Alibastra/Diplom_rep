using System.Collections.Generic;
using Hotel.Models;
using Hotel.Models.ViewModels;

namespace Hotel.Models.ViewModels
{
    public class CustomersListViewModel
    {
        public IEnumerable<Customer> Customers { get; set; }
        public PagingInfo PagingInfo { get; set; }
        public string LastName { get; set; }
    }
}
