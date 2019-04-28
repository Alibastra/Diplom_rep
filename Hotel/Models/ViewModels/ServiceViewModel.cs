using System.Collections.Generic;
using Hotel.Models;
using Hotel.Models.ViewModels;

namespace Hotel.Models.ViewModels
{
    public class ServiceViewModel
    {
        public Service Service { get; set; }
        public string ReturnUrl { get; set; }
    }
}
