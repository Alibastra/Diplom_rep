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
        [Range(1,int.MaxValue,ErrorMessage = "Пожалуста, введите корректный номер комнаты!")]
        public int  RoomID { get; set; }

        [Required(ErrorMessage = "Пожалуста, выберите категорию!")]
        public string Category { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Пожалуста, введите количество мест!")]
        public int Quantity { get; set; }

        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Пожалуста, введите цену!")]
        public decimal Price { get; set; }

        public string Comments { get; set; }
        
        public bool State { get; set; } 
    }
}
