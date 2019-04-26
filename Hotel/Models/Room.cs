using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Hotel.Models
{
    public class Room
    {
        [Required]
        [Range(1,int.MaxValue,ErrorMessage = "Please enter correct room number")]
        public int  RoomID { get; set; }

        [Required(ErrorMessage = "Please specify category")]
        public string Category { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Please enter quantity")]
        public int Quantity { get; set; }

        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Please enter price")]
        public decimal Price { get; set; }

        public string Comments { get; set; }
        
        [Required(ErrorMessage = "Please choose State")]
        public bool State { get; set; } 
    }
}
