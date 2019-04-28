using System.Collections.Generic;
using Hotel.Models;
using Hotel.Models.ViewModels;

namespace Hotel.Models.ViewModels
{
    public class CustomerViewModel
    {
        public Customer Customer { get; set; }
        public string ReturnUrl { get; set; }
    }
}
