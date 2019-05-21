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

        [Required]
        public int ServiceID { get; set; }

        [Required]
        public DateTime SupplyDate { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public int CheckInID { get; set; }
    }
}
