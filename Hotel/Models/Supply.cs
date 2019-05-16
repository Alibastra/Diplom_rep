using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel.Models
{
    public class Supply
    {
        [Key]
        public int SupplyID { get; set; }
        public int ServiceID { get; set; }
        public DateTime SupplyDate { get; set; }
        public int Quantity { get; set; }
        public int CheckInID { get; set; }
    }
}
